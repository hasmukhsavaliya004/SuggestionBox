using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using SuggestionBox.Repositories;

namespace SuggestionBox.Controllers
{
    public class APIController : ApiController
    {
        private SuggestionRepository objSuggestionRepository;

        private APIController()
        {
            this.objSuggestionRepository = new SuggestionRepository();
        }

        // GET api/api
        public List<Suggestion> Get()
        {
            return this.objSuggestionRepository.GetAllSuggestion();
        }

        // GET api/api/5
        public Suggestion Get(int id)
        {
            return this.objSuggestionRepository.GetAllSuggestion().Where(w=>w.SuggestionId == id).FirstOrDefault();
        }

        // POST api/api
        public int Post(Suggestion objSuggestion)
        {
            return this.objSuggestionRepository.AddSuggestion(objSuggestion);
        }

        // PUT api/api/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/api/5
        public int Delete(int id)
        {
            Suggestion objSuggestion = new Suggestion(){SuggestionId = id};
            return this.objSuggestionRepository.RemoveSuggestion(objSuggestion);
        }
    }
}
