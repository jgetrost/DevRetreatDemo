namespace Strengths.Shared.Models {
    using System.Collections.Generic;
    using System.Linq;
    public class User {
        public int Id { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string FullName { 
            get { return string.Format("{0} {1}", this.FirstName, this.LastName); }
        }

        public virtual Theme Theme1 { get; set; }

        public virtual Theme Theme2 { get; set; }

        public virtual Theme Theme3 { get; set; }

        public virtual Theme Theme4 { get; set; }

        public virtual Theme Theme5 { get; set; }

        public bool CheckThemesAreUnique(){
            List<Theme> _themes = new List<Theme>();
            _themes.Add(this.Theme1);
            _themes.Add(this.Theme2);
            _themes.Add(this.Theme3);
            _themes.Add(this.Theme4);
            _themes.Add(this.Theme5);

            if(_themes.Count != _themes.Distinct().Count())
            {
                return false;
            }else{
                return true;
            }
        }
    }
}