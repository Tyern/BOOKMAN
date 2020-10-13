using System;
using System.Text.RegularExpressions;
using System.Text;

namespace Bookman.ConsoleApp.Framework
{
    // create the dictionary that link between the string contains
    // the command and command function
    using RoutingTable = System.Collections.Generic.
        Dictionary<string, ControllersAction>;

    // the function reference type for each command
    public delegate void ControllersAction(Parameter parameter = null);

    public class Router
    {
        private static Router _instance;
        private readonly RoutingTable _routingTable;

        private readonly System.Collections.Generic
            .Dictionary<string, string> _helpTable;

        private Router()
        {
            _routingTable = new RoutingTable();
            _helpTable = new System.Collections.Generic
                .Dictionary<string, string>();
        }

        public static Router Instance => _instance ?? (_instance = new Router());

        public string GetRoute()
        {
            // the string which is mutable, using the method AppendFormat
            // to append string to the end of the original string.
            StringBuilder sb = new StringBuilder();
            foreach (var k in _routingTable.Keys)
            {
                sb.AppendFormat($"{k}, ");
            }
            return sb.ToString();
        }

        public string GetHelp(string key)
        {
            ViewHelp.WriteLine($"key:{key}");

            if (_helpTable.ContainsKey(key))
            {
                return _helpTable[key];
            }
            return "Documentation is not ready";
        }

        public void Register(string route, ControllersAction action, string help = "")
        {
            if (!_routingTable.ContainsKey(route))
            {
                _routingTable[route] = action;
                _helpTable[route] = help;
            }
            else
            {
                ViewHelp.WriteLine($"The action [{route}] existed in Routing Table", ConsoleColor.Red);
            }
        }

        /// <summary>
        /// Invoke the function with the raw request from Client
        /// </summary>
        /// <param name="request"></param>
        public void Forward(string request)
        {
            var req = new Request(request);

            if (req.Route == null) return;

            if (!_routingTable.ContainsKey(req.Route))
            {
                ViewHelp.WriteLine("The command is not invalid\n>>> See help", ConsoleColor.Red);
                return;
            }

            if (req.Parameter == null)
            {
                _routingTable[req.Route]?.Invoke();
            }
            else
            {
                // invoke with parameters
                _routingTable[req.Route]?.Invoke(req.Parameter);
            }
        }

        private class Request
        {
            public string Route { get; private set; }

            public Parameter Parameter { get; private set; }

            public Request (string request)
            {
                request = request.Trim();
                Analyze(request);
            }

            private void Analyze(string request)
            {
                if (request== "")
                {
                    Route = null;
                    Parameter = new Parameter("");
                    return;
                }

                // using regex to match the request and return 2 match group
                Regex regex = new Regex(@"^\s*(\w+)\s*(?:\?([a-zA-Z0-9= ]*))?$");

                if (!regex.IsMatch(request))
                {
                    ViewHelp.WriteLine("The command format is not valid", ConsoleColor.Red);
                }
                else
                {
                    Match match = regex.Match(request);

                    //group => [full-match | group1 | group2 ]

                    Route = match.Groups[1].Value.Trim().ToLower();

                    string parametersString = match.Groups[2].Value.Trim();

                    // initialize the parameters contain the Parameter information
                    Parameter = new Parameter(parametersString);

                }
            }
        }
    }
}
