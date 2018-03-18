using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Globalization;

using api.Models;
using api.Models.Definitions;

namespace api.Data
{
    public static class MockData
    {
        readonly static string dtformat = "yyyy-MM-ddTHH:mm";

        private static DateTime ParseDT(string dt)
        {
            return DateTime.ParseExact(dt, dtformat, CultureInfo.InvariantCulture);
        }

        public static Nuance[] GenerateDefaults()
        {
            List<Nuance> nuances = new List<Nuance>();

            nuances.Add(Make1());
            nuances.Add(Make2());
            nuances.Add(Make3());

            return nuances.ToArray();
        }

        public static Nuance GenerateShipment()
        {
            return Make4();
        }

        static Nuance Make3()
        {
            Nuance nuance = new Nuance
            {
                Title = "#6200414323066",
                Description = "Shipment country, address, asset description, etc. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor",
                Details = "Origin:Toronto Canada;Origin Date:28 March 2017;Destination:Singapore;Destination Date:5 April 2017",
                ShipperName = "Ayoh Shipping Ltd",
                CreatedDT = ParseDT("2017-03-28T09:52"),
                DueDT = ParseDT("2017-04-05T08:30"),
                Priority = Priority.Normal
            };

            nuance.Waypoints = new List<Waypoint>();
            nuance.Waypoints.Add(new Waypoint
            {
                Title = "ON, Canada",
                ArriveDT = null,
                DepartDT = ParseDT("2017-03-28T22:03"),
                Status = WaypointStatus.Previous,
                Path = WaypointPath.AtStart,
                Order = 0,
                BlockChain = 1,

            });

            nuance.Waypoints.Add(new Waypoint
            {
                Title = "NY, USA",
                ArriveDT = ParseDT("2017-03-29T12:57"),
                DepartDT = ParseDT("2017-03-31T15:40"),
                Status = WaypointStatus.Previous,
                Path = WaypointPath.Middle,
                Order = 1,
                BlockChain = 1
            });

            nuance.Waypoints.Add(new Waypoint
            {
                Title = "ZN, Africa",
                ArriveDT = ParseDT("2017-04-01T19:33"),
                DepartDT = ParseDT("2017-04-02T16:44"),
                Status = WaypointStatus.Previous,
                Path = WaypointPath.Middle,
                Order = 2,
                BlockChain = -1
            });

            nuance.Waypoints.Add(new Waypoint
            {
                Title = "BOM, India",
                ArriveDT = ParseDT("2017-04-04T18:57"),
                DepartDT = ParseDT("2017-04-04T22:00"),
                Status = WaypointStatus.Current,
                Path = WaypointPath.Middle,
                Order = 3,
                BlockChain = 1
            });

            nuance.Waypoints.Add(new Waypoint
            {
                Title = "KL, Malaysia",
                ArriveDT = ParseDT("2017-04-05T14:30"),
                DepartDT = ParseDT("2017-04-05T15:00"),
                Status = WaypointStatus.Next,
                Path = WaypointPath.Middle,
                Order = 4,
                BlockChain = 0
            });

            nuance.Waypoints.Add(new Waypoint
            {
                Title = "SG, Singapore",
                ArriveDT = ParseDT("2017-04-05T19:00"),
                DepartDT = null,
                Status = WaypointStatus.Next,
                Path = WaypointPath.AtEnd,
                Order = 5,
                BlockChain = 0
            });

            return nuance;
        }

        static Nuance Make2()
        {
            Nuance nuance = new Nuance
            {
                Title = "#6200414323064",
                Description = "Shipment country, address, asset description, etc. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor",
                Details = "Origin:London, UK;Origin Date:25 March 2017;Destination:Indonesia;Destination Date:4 April 2017",
                ShipperName = "Alamak Shipping Pty Ltd",
                CreatedDT = ParseDT("2017-03-25T19:45"),
                DueDT = ParseDT("2017-04-04T11:00"),
                Priority = Priority.High
            };

            nuance.Waypoints = new List<Waypoint>();
            nuance.Waypoints.Add(new Waypoint
            {
                Title = "ON, Canada",
                ArriveDT = null,
                DepartDT = ParseDT("2017-03-28T22:03"),
                Status = WaypointStatus.Previous,
                Path = WaypointPath.AtStart,
                Order = 0,
                BlockChain = 1,

            });

            nuance.Waypoints.Add(new Waypoint
            {
                Title = "NY, USA",
                ArriveDT = ParseDT("2017-03-29T12:57"),
                DepartDT = ParseDT("2017-03-31T15:40"),
                Status = WaypointStatus.Previous,
                Path = WaypointPath.Middle,
                Order = 1,
                BlockChain = 1
            });

            nuance.Waypoints.Add(new Waypoint
            {
                Title = "ZN, Africa",
                ArriveDT = ParseDT("2017-04-01T19:33"),
                DepartDT = ParseDT("2017-04-02T16:44"),
                Status = WaypointStatus.Previous,
                Path = WaypointPath.Middle,
                Order = 2,
                BlockChain = -1
            });

            nuance.Waypoints.Add(new Waypoint
            {
                Title = "BOM, India",
                ArriveDT = ParseDT("2017-04-04T18:57"),
                DepartDT = ParseDT("2017-04-04T22:00"),
                Status = WaypointStatus.Current,
                Path = WaypointPath.Middle,
                Order = 3,
                BlockChain = 1
            });

            nuance.Waypoints.Add(new Waypoint
            {
                Title = "SG, Singapore",
                ArriveDT = ParseDT("2017-04-05T19:00"),
                DepartDT = null,
                Status = WaypointStatus.Next,
                Path = WaypointPath.AtEnd,
                Order = 4,
                BlockChain = 0
            });

            return nuance;
        }

        static Nuance Make1()
        {
            Nuance nuance = new Nuance
            {
                Title = "#6200414323063",
                Description = "Shipment country, address, asset description, etc. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor",
                Details = "Origin:Shenzhen, China;Origin Date:20 March 2017;Destination:New York, USA;Destination Date:30 March 2017",
                ShipperName = "Super Transport Ltd",
                CreatedDT = ParseDT("2017-03-20T19:45"),
                DueDT = ParseDT("2017-03-30T19:00"),
                Priority = Priority.Normal
            };

            nuance.Waypoints = new List<Waypoint>();
            nuance.Waypoints.Add(new Waypoint
            {
                Title = "ON, Canada",
                ArriveDT = null,
                DepartDT = ParseDT("2017-03-28T22:03"),
                Status = WaypointStatus.Previous,
                Path = WaypointPath.AtStart,
                Order = 0,
                BlockChain = 1,

            });

            nuance.Waypoints.Add(new Waypoint
            {
                Title = "NY, USA",
                ArriveDT = ParseDT("2017-03-29T12:57"),
                DepartDT = ParseDT("2017-03-31T15:40"),
                Status = WaypointStatus.Previous,
                Path = WaypointPath.Middle,
                Order = 1,
                BlockChain = 1
            });

            nuance.Waypoints.Add(new Waypoint
            {
                Title = "ZN, Africa",
                ArriveDT = ParseDT("2017-04-01T19:33"),
                DepartDT = ParseDT("2017-04-02T16:44"),
                Status = WaypointStatus.Previous,
                Path = WaypointPath.Middle,
                Order = 2,
                BlockChain = -1
            });

            nuance.Waypoints.Add(new Waypoint
            {
                Title = "BOM, India",
                ArriveDT = ParseDT("2017-04-04T18:57"),
                DepartDT = ParseDT("2017-04-04T22:00"),
                Status = WaypointStatus.Current,
                Path = WaypointPath.Middle,
                Order = 3,
                BlockChain = 1
            });

            nuance.Waypoints.Add(new Waypoint
            {
                Title = "KL, Malaysia",
                ArriveDT = ParseDT("2017-04-05T14:30"),
                DepartDT = ParseDT("2017-04-05T15:00"),
                Status = WaypointStatus.Next,
                Path = WaypointPath.Middle,
                Order = 4,
                BlockChain = 0
            });


            nuance.Waypoints.Add(new Waypoint
            {
                Title = "IN, Indonesia",
                ArriveDT = ParseDT("2017-04-07T11:30"),
                DepartDT = ParseDT("2017-04-08T12:00"),
                Status = WaypointStatus.Next,
                Path = WaypointPath.Middle,
                Order = 5,
                BlockChain = 0
            });

            nuance.Waypoints.Add(new Waypoint
            {
                Title = "NY, USA",
                ArriveDT = ParseDT("2017-04-09T19:00"),
                DepartDT = null,
                Status = WaypointStatus.Next,
                Path = WaypointPath.AtEnd,
                Order = 6,
                BlockChain = 0
            });

            return nuance;
        }

        static Nuance Make4()
        {
            Nuance nuance = new Nuance
            {
                Title = "#62004143230670",
                Description = "(New) Shipment country, address, asset description, etc. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor",
                Details = "Origin:Shenzhen, China;Origin Date:20 March 2017;Destination:New York, USA;Destination Date:30 March 2017",
                ShipperName = "SuperX Transport Ltd",
                CreatedDT = ParseDT("2017-03-20T19:45"),
                DueDT = ParseDT("2017-03-30T19:00"),
                Priority = Priority.Normal
            };

            nuance.Waypoints = new List<Waypoint>();
            nuance.Waypoints.Add(new Waypoint
            {
                Title = "ON, Canada",
                ArriveDT = null,
                DepartDT = ParseDT("2017-03-28T22:03"),
                Status = WaypointStatus.Previous,
                Path = WaypointPath.AtStart,
                Order = 0,
                BlockChain = 1,

            });

            nuance.Waypoints.Add(new Waypoint
            {
                Title = "NY, USA",
                ArriveDT = ParseDT("2017-03-29T12:57"),
                DepartDT = ParseDT("2017-03-31T15:40"),
                Status = WaypointStatus.Previous,
                Path = WaypointPath.Middle,
                Order = 1,
                BlockChain = 1
            });

            nuance.Waypoints.Add(new Waypoint
            {
                Title = "ZN, Africa",
                ArriveDT = ParseDT("2017-04-01T19:33"),
                DepartDT = ParseDT("2017-04-02T16:44"),
                Status = WaypointStatus.Previous,
                Path = WaypointPath.Middle,
                Order = 2,
                BlockChain = -1
            });

            nuance.Waypoints.Add(new Waypoint
            {
                Title = "BOM, India",
                ArriveDT = ParseDT("2017-04-04T18:57"),
                DepartDT = ParseDT("2017-04-04T22:00"),
                Status = WaypointStatus.Current,
                Path = WaypointPath.Middle,
                Order = 3,
                BlockChain = 1
            });

            nuance.Waypoints.Add(new Waypoint
            {
                Title = "KL, Malaysia",
                ArriveDT = ParseDT("2017-04-05T14:30"),
                DepartDT = ParseDT("2017-04-05T15:00"),
                Status = WaypointStatus.Next,
                Path = WaypointPath.Middle,
                Order = 4,
                BlockChain = 0
            });


            nuance.Waypoints.Add(new Waypoint
            {
                Title = "IN, Indonesia",
                ArriveDT = ParseDT("2017-04-07T11:30"),
                DepartDT = ParseDT("2017-04-08T12:00"),
                Status = WaypointStatus.Next,
                Path = WaypointPath.Middle,
                Order = 5,
                BlockChain = 0
            });

            nuance.Waypoints.Add(new Waypoint
            {
                Title = "NY, USA",
                ArriveDT = ParseDT("2017-04-09T19:00"),
                DepartDT = null,
                Status = WaypointStatus.Next,
                Path = WaypointPath.AtEnd,
                Order = 6,
                BlockChain = 0
            });

            return nuance;
        }

    }
}
