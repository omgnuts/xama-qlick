namespace Trak.Client.Portable.Common
{
    public static class SampleBase64
    {
        public static string SampleData(string ext)
        {
            if (ext.ToLower().Equals("pdf"))
                return SamplePDF;

            if (ext.ToLower().Equals("jpg"))
                return SampleJPG;

            if (ext.ToLower().Equals("bitmap"))
                return SampleJPG;

            return null;
        }

        static string SamplePDF 
        {
            get
            {
                string base64 =
                    "JVBERi0xLjcKCjEgMCBvYmogICUgZW50cnkgcG9pbnQKPDwKICAvVHlwZSAvQ2F0YWxvZwog" +
                  "IC9QYWdlcyAyIDAgUgo+PgplbmRvYmoKCjIgMCBvYmoKPDwKICAvVHlwZSAvUGFnZXMKICAv" +
                  "TWVkaWFCb3ggWyAwIDAgMjAwIDIwMCBdCiAgL0NvdW50IDEKICAvS2lkcyBbIDMgMCBSIF0K" +
                  "Pj4KZW5kb2JqCgozIDAgb2JqCjw8CiAgL1R5cGUgL1BhZ2UKICAvUGFyZW50IDIgMCBSCiAg" +
                  "L1Jlc291cmNlcyA8PAogICAgL0ZvbnQgPDwKICAgICAgL0YxIDQgMCBSIAogICAgPj4KICA+" +
                  "PgogIC9Db250ZW50cyA1IDAgUgo+PgplbmRvYmoKCjQgMCBvYmoKPDwKICAvVHlwZSAvRm9u" +
                  "dAogIC9TdWJ0eXBlIC9UeXBlMQogIC9CYXNlRm9udCAvVGltZXMtUm9tYW4KPj4KZW5kb2Jq" +
                  "Cgo1IDAgb2JqICAlIHBhZ2UgY29udGVudAo8PAogIC9MZW5ndGggNDQKPj4Kc3RyZWFtCkJU" +
                  "CjcwIDUwIFRECi9GMSAxMiBUZgooSGVsbG8sIHdvcmxkISkgVGoKRVQKZW5kc3RyZWFtCmVu" +
                  "ZG9iagoKeHJlZgowIDYKMDAwMDAwMDAwMCA2NTUzNSBmIAowMDAwMDAwMDEwIDAwMDAwIG4g" +
                  "CjAwMDAwMDAwNzkgMDAwMDAgbiAKMDAwMDAwMDE3MyAwMDAwMCBuIAowMDAwMDAwMzAxIDAw" +
                  "MDAwIG4gCjAwMDAwMDAzODAgMDAwMDAgbiAKdHJhaWxlcgo8PAogIC9TaXplIDYKICAvUm9v" +
                    "dCAxIDAgUgo+PgpzdGFydHhyZWYKNDkyCiUlRU9G";

                return base64;
            }
        }


        static string SampleJPG 
        {
            get
            {
                string base64 =
                    "/9j/4AAQSkZJRgABAQAAAQABAAD/2wCEAAkGBwgHBgkIBwgKCgkLDRYPDQwMDRsU" +
                    "FRAWIB0iIiAdHx8kKDQsJCYxJx8fLT0tMTU3Ojo6Iys/RD81QzQ5OjcBCgoKDQwN" +
                    "Gg8PGjclHyU3Nzc3Nzc3Nzc3NzcwNzc3LTc1NzctLzc4NTc3Nzc3LSs3NzU3Ky03" +
                    "Nzc3NS0rMi03Nv/AABEIAB4AHgMBIgACEQEDEQH/xAAXAAADAQAAAAAAAAAAAAAA" +
                    "AAAFBgcE/8QALRAAAgEDAgUCBAcAAAAAAAAAAQIDBAURAAYSITFBYRMUB5Gh4SJC" +
                    "UWNxgcL/xAAXAQEBAQEAAAAAAAAAAAAAAAADAgQB/8QAHBEAAgMAAwEAAAAAAAAA" +
                    "AAAAAQIAAxEEEiFB/9oADAMBAAIRAxEAPwC3HQK/SXOO6WlKKoSKkmmKVGVBJwCw" +
                    "GcHrwsPlo7oFuq426io4o7hVCB5ZUMDEZIdWBzy7DAz99S2ZErB7eCCrBtinNknZ" +
                    "aidKqqaRlmV2UwnJAwAe2M+dGdopMu3aP3c71ErKWMsjFi2SSDz8YxpAuNfZYLpS" +
                    "XAXmoealL4gpELAguxH4jgdG5jv01RtvTU89koXoi3t/QUR56gAYwcd/10deE4Jo" +
                    "5CuF0/Yq/Eu93izNSC31HpQTqwYhATxDHcjz9NI9+qp7rYbVcKiZ5ZY2kppmY/mB" +
                    "4l/vhbr41RvidQCs25xggPDOhUnyeH/X01lse0Gnpaobi9tPFUSRypDTZRUYKRkY" +
                    "x1BGjdWZysei6uupXI9Bkj1ZfhaHG1I+IKAZnKkZyRnv569PGtlFsjbtI3qJbkkb" +
                    "95i4+R5aYII0jjVIUVEA5KowAP412qkqdMnl81Ll6KJ//9k=";
                return base64;
            }
        }
    }
}
