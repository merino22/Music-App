using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssistantManager.API.DataTransferObjects
{
    public class ListSongsDTO
    {
        public string ListName { get; set; }

        public IEnumerable<string> Songs { get; set; }
    }
}
