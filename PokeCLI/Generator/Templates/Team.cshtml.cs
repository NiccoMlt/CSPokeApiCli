using System.Collections;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc.RazorPages;
using PokeCLI.Showdown;

namespace PokeCLI.Generator.Templates
{
    public class Team : PageModel, ITeam
    {
        public Team(ITeam model)
        {
            this.Model = model;
        }

        public ITeam Model { private get; set; }

        public void OnGet()
        {
        }

        public IEnumerator<IPokemonSet> GetEnumerator()
        {
            throw new System.NotImplementedException();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public string Name => Model.Name;

        public string Format => Model.Format;

        public IList<IPokemonSet> Members => Model.Members;
    }
}
