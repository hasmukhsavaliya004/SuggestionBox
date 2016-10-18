using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SuggestionBox.Repositories
{

    public class SuggestionRepository
    {
        private SuggestionBoxDBEntities db;
        public SuggestionRepository()
        {
            this.db = new SuggestionBoxDBEntities();
        }

        public int AddSuggestion(Suggestion objSuggestions)
        {
            db.Suggestions.Add(objSuggestions);
            return db.SaveChanges();
        }

        public List<Suggestion> GetAllSuggestion()
        {
            return db.Suggestions.ToList();
        }

        public int RemoveSuggestion(Suggestion objSuggestions)
        {
            Suggestion selected = db.Suggestions.Where(s => s.SuggestionId == objSuggestions.SuggestionId).SingleOrDefault();
            db.Suggestions.Remove(selected);
            return db.SaveChanges();
        }
    }
}