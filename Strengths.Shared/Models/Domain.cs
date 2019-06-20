namespace Strengths.Shared.Models {
    using System.Collections.Generic;
    using System.Runtime.Serialization;
    using Microsoft.EntityFrameworkCore;
    using Newtonsoft.Json;
    public class Domain {
        public int Id { get; set; }

        public string Title { get; set; }
    }
}