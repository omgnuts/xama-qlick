using System;
using System.Collections.Generic;
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

        public static List<Document> GenerateDocument(BlockChained bc = BlockChained.Locked, string prefix = "Document ", int count = 5)
        {

            List<Document> docs = new List<Document>();

            for (int c = 0; c < count; c++)
            {

                Document doc = new Document
                {
                    Title = $"{prefix} - {c + 1}",
                    Description = $"Description - eg. bill of lading for transport, customs, etc",
                    BlockChain = bc
                };

                docs.Add(doc);
            }

            return docs;
        }

        static Nuance Make3()
        {
            Nuance nuance = new Nuance
            {
                Title = "#6200414323066",
                Description = "Shipment country, address, asset description, etc. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor",
                Details = "Origin:Toronto Canada;Origin Date:28 March 2018;Destination:Singapore;Destination Date:5 April 2018",
                ShipperName = "Ayoh Shipping Ltd",
                CreatedDT = ParseDT("2018-03-28T09:52"),
                DueDT = ParseDT("2018-04-05T08:30"),
                Priority = Priority.Normal
            };

            nuance.Waypoints = new List<Waypoint>();
            nuance.Waypoints.Add(new Waypoint
            {
                Title = "ON, Canada",
                ArriveDT = null,
                DepartDT = ParseDT("2018-03-28T22:03"),
                Status = WaypointStatus.Completed,
                Path = WaypointPath.AtStart,
                Order = 0,
                Documents = GenerateDocument(BlockChained.Locked, "Customs ", 2),
            });

            nuance.Waypoints.Add(new Waypoint
            {
                Title = "NY, USA",
                ArriveDT = ParseDT("2018-03-29T12:57"),
                DepartDT = ParseDT("2018-03-31T15:40"),
                Status = WaypointStatus.Completed,
                Path = WaypointPath.Middle,
                Order = 1,
                Documents = GenerateDocument(),
            });

            nuance.Waypoints.Add(new Waypoint
            {
                Title = "ZN, Africa",
                ArriveDT = ParseDT("2018-04-01T19:33"),
                DepartDT = ParseDT("2018-04-02T16:44"),
                Status = WaypointStatus.Completed,
                Path = WaypointPath.Middle,
                Order = 2,
                Documents = GenerateDocument(BlockChained.Broken),
            });

            nuance.Waypoints.Add(new Waypoint
            {
                Title = "BOM, India",
                ArriveDT = ParseDT("2018-04-04T18:57"),
                DepartDT = ParseDT("2018-04-04T22:00"),
                Status = WaypointStatus.Current,
                Path = WaypointPath.Middle,
                Order = 3,
                Documents = GenerateDocument(),
            });

            nuance.Waypoints.Add(new Waypoint
            {
                Title = "KL, Malaysia",
                ArriveDT = ParseDT("2018-04-05T14:30"),
                DepartDT = ParseDT("2018-04-05T15:00"),
                Status = WaypointStatus.Uncompleted,
                Path = WaypointPath.Middle,
                Order = 4,
                Documents = GenerateDocument(BlockChained.Open),
            });

            nuance.Waypoints.Add(new Waypoint
            {
                Title = "SG, Singapore",
                ArriveDT = ParseDT("2018-04-05T19:00"),
                DepartDT = null,
                Status = WaypointStatus.Uncompleted,
                Path = WaypointPath.AtEnd,
                Order = 5,
                Documents = GenerateDocument(BlockChained.Open),
            });

            return nuance;
        }

        static Nuance Make2()
        {
            Nuance nuance = new Nuance
            {
                Title = "#6200414323064",
                Description = "Shipment country, address, asset description, etc. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor",
                Details = "Origin:London, UK;Origin Date:25 March 2018;Destination:Indonesia;Destination Date:4 April 2018",
                ShipperName = "Alamak Shipping Pty Ltd",
                CreatedDT = ParseDT("2018-03-25T19:45"),
                DueDT = ParseDT("2018-04-04T11:00"),
                Priority = Priority.High
            };

            nuance.Waypoints = new List<Waypoint>();
            nuance.Waypoints.Add(new Waypoint
            {
                Title = "ON, Canada",
                ArriveDT = null,
                DepartDT = ParseDT("2018-03-28T22:03"),
                Status = WaypointStatus.Completed,
                Path = WaypointPath.AtStart,
                Order = 0,
                Documents = GenerateDocument(),
            });

            nuance.Waypoints.Add(new Waypoint
            {
                Title = "NY, USA",
                ArriveDT = ParseDT("2018-03-29T12:57"),
                DepartDT = ParseDT("2018-03-31T15:40"),
                Status = WaypointStatus.Completed,
                Path = WaypointPath.Middle,
                Order = 1,
                Documents = GenerateDocument(),
            });

            nuance.Waypoints.Add(new Waypoint
            {
                Title = "ZN, Africa",
                ArriveDT = ParseDT("2018-04-01T19:33"),
                DepartDT = ParseDT("2018-04-02T16:44"),
                Status = WaypointStatus.Completed,
                Path = WaypointPath.Middle,
                Order = 2,
                Documents = GenerateDocument(BlockChained.Broken),
            });

            nuance.Waypoints.Add(new Waypoint
            {
                Title = "BOM, India",
                ArriveDT = ParseDT("2018-04-04T18:57"),
                DepartDT = ParseDT("2018-04-04T22:00"),
                Status = WaypointStatus.Current,
                Path = WaypointPath.Middle,
                Order = 3,
                Documents = GenerateDocument(),
            });

            nuance.Waypoints.Add(new Waypoint
            {
                Title = "SG, Singapore",
                ArriveDT = ParseDT("2018-04-05T19:00"),
                DepartDT = null,
                Status = WaypointStatus.Uncompleted,
                Path = WaypointPath.AtEnd,
                Order = 4,
                Documents = GenerateDocument(BlockChained.Open),
            });

            return nuance;
        }

        static Nuance Make1()
        {
            Nuance nuance = new Nuance
            {
                Title = "#6200414323063",
                Description = "Shipment country, address, asset description, etc. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor",
                Details = "Origin:Shenzhen, China;Origin Date:20 March 2018;Destination:New York, USA;Destination Date:30 March 2018",
                ShipperName = "Super Transport Ltd",
                CreatedDT = ParseDT("2018-03-20T19:45"),
                DueDT = ParseDT("2018-03-30T19:00"),
                Priority = Priority.Normal
            };

            nuance.Waypoints = new List<Waypoint>();
            nuance.Waypoints.Add(new Waypoint
            {
                Title = "ON, Canada",
                ArriveDT = null,
                DepartDT = ParseDT("2018-03-28T22:03"),
                Status = WaypointStatus.Completed,
                Path = WaypointPath.AtStart,
                Order = 0,
                Documents = GenerateDocument(),
            });

            nuance.Waypoints.Add(new Waypoint
            {
                Title = "NY, USA",
                ArriveDT = ParseDT("2018-03-29T12:57"),
                DepartDT = ParseDT("2018-03-31T15:40"),
                Status = WaypointStatus.Completed,
                Path = WaypointPath.Middle,
                Order = 1,
                Documents = GenerateDocument(),
            });

            nuance.Waypoints.Add(new Waypoint
            {
                Title = "ZN, Africa",
                ArriveDT = ParseDT("2018-04-01T19:33"),
                DepartDT = ParseDT("2018-04-02T16:44"),
                Status = WaypointStatus.Completed,
                Path = WaypointPath.Middle,
                Order = 2,
                Documents = GenerateDocument(BlockChained.Broken),
            });

            nuance.Waypoints.Add(new Waypoint
            {
                Title = "BOM, India",
                ArriveDT = ParseDT("2018-04-04T18:57"),
                DepartDT = ParseDT("2018-04-04T22:00"),
                Status = WaypointStatus.Current,
                Path = WaypointPath.Middle,
                Order = 3,
                Documents = GenerateDocument(),
            });

            nuance.Waypoints.Add(new Waypoint
            {
                Title = "KL, Malaysia",
                ArriveDT = ParseDT("2018-04-05T14:30"),
                DepartDT = ParseDT("2018-04-05T15:00"),
                Status = WaypointStatus.Uncompleted,
                Path = WaypointPath.Middle,
                Order = 4,
                Documents = GenerateDocument(BlockChained.Open),
            });


            nuance.Waypoints.Add(new Waypoint
            {
                Title = "IN, Indonesia",
                ArriveDT = ParseDT("2018-04-07T11:30"),
                DepartDT = ParseDT("2018-04-08T12:00"),
                Status = WaypointStatus.Uncompleted,
                Path = WaypointPath.Middle,
                Order = 5,
                Documents = GenerateDocument(BlockChained.Open),
            });

            nuance.Waypoints.Add(new Waypoint
            {
                Title = "NY, USA",
                ArriveDT = ParseDT("2018-04-09T19:00"),
                DepartDT = null,
                Status = WaypointStatus.Uncompleted,
                Path = WaypointPath.AtEnd,
                Order = 6,
                Documents = GenerateDocument(BlockChained.Open),
            });

            return nuance;
        }

        static Nuance Make4()
        {
            Nuance nuance = new Nuance
            {
                Title = "#62004143230670",
                Description = "(New) Shipment country, address, asset description, etc. Lorem ipsum dolor sit amet, consectetuer adipiscing elit. Aenean commodo ligula eget dolor",
                Details = "Origin:Shenzhen, China;Origin Date:20 March 2018;Destination:New York, USA;Destination Date:30 March 2018",
                ShipperName = "SuperX Transport Ltd",
                CreatedDT = ParseDT("2018-03-20T19:45"),
                DueDT = ParseDT("2018-03-30T19:00"),
                Priority = Priority.Normal
            };

            nuance.Waypoints = new List<Waypoint>();
            nuance.Waypoints.Add(new Waypoint
            {
                Title = "ON, Canada",
                ArriveDT = null,
                DepartDT = ParseDT("2018-03-28T22:03"),
                Status = WaypointStatus.Completed,
                Path = WaypointPath.AtStart,
                Order = 0,
                Documents = GenerateDocument(),
            });

            nuance.Waypoints.Add(new Waypoint
            {
                Title = "NY, USA",
                ArriveDT = ParseDT("2018-03-29T12:57"),
                DepartDT = ParseDT("2018-03-31T15:40"),
                Status = WaypointStatus.Completed,
                Path = WaypointPath.Middle,
                Order = 1,
                Documents = GenerateDocument(),
            });

            nuance.Waypoints.Add(new Waypoint
            {
                Title = "ZN, Africa",
                ArriveDT = ParseDT("2018-04-01T19:33"),
                DepartDT = ParseDT("2018-04-02T16:44"),
                Status = WaypointStatus.Completed,
                Path = WaypointPath.Middle,
                Order = 2,
                Documents = GenerateDocument(BlockChained.Broken),
            });

            nuance.Waypoints.Add(new Waypoint
            {
                Title = "BOM, India",
                ArriveDT = ParseDT("2018-04-04T18:57"),
                DepartDT = ParseDT("2018-04-04T22:00"),
                Status = WaypointStatus.Current,
                Path = WaypointPath.Middle,
                Order = 3,
                Documents = GenerateDocument(),
            });

            nuance.Waypoints.Add(new Waypoint
            {
                Title = "KL, Malaysia",
                ArriveDT = ParseDT("2018-04-05T14:30"),
                DepartDT = ParseDT("2018-04-05T15:00"),
                Status = WaypointStatus.Uncompleted,
                Path = WaypointPath.Middle,
                Order = 4,
                Documents = GenerateDocument(BlockChained.Open),
            });


            nuance.Waypoints.Add(new Waypoint
            {
                Title = "IN, Indonesia",
                ArriveDT = ParseDT("2018-04-07T11:30"),
                DepartDT = ParseDT("2018-04-08T12:00"),
                Status = WaypointStatus.Uncompleted,
                Path = WaypointPath.Middle,
                Order = 5,
                Documents = GenerateDocument(BlockChained.Open),
            });

            nuance.Waypoints.Add(new Waypoint
            {
                Title = "NY, USA",
                ArriveDT = ParseDT("2018-04-09T19:00"),
                DepartDT = null,
                Status = WaypointStatus.Uncompleted,
                Path = WaypointPath.AtEnd,
                Order = 6,
                Documents = GenerateDocument(BlockChained.Open),
            });

            return nuance;
        }

    }
}
