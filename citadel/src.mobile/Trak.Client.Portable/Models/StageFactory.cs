using System.Collections.Generic;

namespace Trak.Client.Portable.Models
{
    public static class StageFactory
    {
        public static List<Stage> GenerateDefaults() {
            
            List<Stage> stages = new List<Stage>();

            stages.Add(CreateStage(
                order: 0,
                title: "A. Shipping",
                subtitle: "Start of Shipment",
                stageItems: new string[] {
                    "Bill of Lading"
                }
            ));

            stages.Add(CreateStage(
                order: 1,
                title: "B. Cargo Transport from Receiving Port",
                subtitle: "Offload Port",
                stageItems: new string[] {
                    "Customs Document",
                    "Cargo Loaded Into Truck #1",
                    "Photograph of Armed Truck",
                    "Cargo Movement Tracking"
                }
            ));

            stages.Add(CreateStage(
                order: 2,
                title: "C. Warehouse Storage",
                subtitle: "Warehouse",
                stageItems: new string[] {
                    "Warehouse Receipt",
                    "Cargo Storage Monitoring",
                    "Status Reporting"
                }
            ));

            stages.Add(CreateStage(
                order: 3,
                title: "D. Buyer Claims Cargo",
                subtitle: "Repurchase of Goods",
                stageItems: new string[] {
                    "Finance Issue Release Instructions to CM",
                    "Cargo Released to Buyer"
                }
            ));

            return stages;
        }

        static Stage CreateStage(int order, string title, string subtitle, string[] stageItems) {
            
            Stage stage = new Stage
            {
                Title = title,
                SubTitle = subtitle,
                Order = order,
            };

            int count = 0;

            foreach (string si in stageItems) {
                stage.StageItems.Add(new StageItem
                {
                    Title = si,
                    Order = count++,
                });
            }

            return stage;
        }
    }
}
