namespace Strengths.Shared.Models {
    public class Theme {
        public int Id { get; set; }

        public string Title { get; set; }

        public virtual Domain Domain { get; set; }
    }
}