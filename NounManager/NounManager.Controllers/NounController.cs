using NounManager.Data;
using NounManager.Models;
using NounManager.Views;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace NounManager.Controllers
{
    public class NounController
    {
        public void Run()
        {
            NounView view = new NounView();

            while (true)
            {
                view.Clear();
                view.DisplaySelectScreen();
                int userChoice = view.GetMenuchoice();

                switch (userChoice)
                {
                    case 1:
                        CreateNoun();
                        break;
                    case 2:
                        DisplayNouns();
                        break;
                    case 3:
                        SearchNoun();
                        break;
                    case 4:
                        EditNoun();
                        break;
                    default:
                        RemoveNoun();
                        break;
                }
            }
        }
        private void CreateNoun()
        {
            NounView view = new NounView();
            NounRepository repo = new NounRepository();

            view.Clear();
            Noun currentNoun = view.GetNewNounInfo();
            repo.Create(currentNoun);

            view.Clear();
            view.DisplayCategories();
            view.DisplayNoun(currentNoun);

            view.Wait();
        }
        private void DisplayNouns()
        {
            NounRepository repo = new NounRepository();
            NounView view = new NounView();

            List<Noun> currentList = repo.ReadAll();

            view.Clear();
            view.DisplayCategories();
            foreach (Noun noun in currentList)
                view.DisplayNoun(noun);

            view.Wait();
        }
        private void SearchNoun()
        {
            NounView view = new NounView();
            NounRepository repo = new NounRepository();

            view.Clear();
            int id = view.SearchNoun();

            Noun currentNoun = repo.ReadById(id);

            if (currentNoun != null)
            {
                view.DisplayCategories();
                view.DisplayNoun(currentNoun);
            }
            else
                view.NotFound();

            view.Wait();
        }
        private void EditNoun()
        {
            NounView view = new NounView();
            NounRepository repo = new NounRepository();

            view.Clear();
            int id = view.SearchNoun();
            Noun currentNoun = repo.ReadById(id);

            if (currentNoun != null)
            {
                view.DisplayCategories();
                view.DisplayNoun(currentNoun);
                string title = view.EditNounTitle(currentNoun);
                string author = view.EditNounAuthor(currentNoun);
                int date = view.EditNounDatePublished(currentNoun);
                bool award = view.EditNounAwardWinner(currentNoun);

                repo.Update(currentNoun, title, author, date, award);
                view.DisplayCategories();
                view.DisplayNoun(currentNoun);
            }
            else
                view.NotFound();
            view.Wait();
        }
        private void RemoveNoun()
        {
            NounView view = new NounView();
            NounRepository repo = new NounRepository();

            view.Clear();
            int id = view.SearchNoun();

            view.DisplayCategories();
            Noun currentNoun = repo.ReadById(id);

            if (currentNoun != null)
                if (view.ConfirmRemoveNoun(currentNoun))
                {
                    repo.Delete(id);
                    view.SomethingHappened(id);
                }
                else
                    view.NothingHappened();
            else
                view.NotFound();
            view.Wait();
        }
    }
}
