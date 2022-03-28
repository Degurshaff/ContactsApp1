using System;
using System.Collections.Generic;
using System.Linq;

namespace ContactsApp
{
    public class Project: IEquatable<Project>
    {
        /// <summary>
        /// Список из объектов класа Contact
        /// </summary>
        public List<Contact> _contactlist { get; set; } = new List<Contact>(0);

        /// <summary>
        /// Поиск контактов содержаших в своей фамилии определенную строчку
        /// </summary>
        /// <returns></returns>
        public List<Contact> SortList()
        {
            var sortedList = _contactlist.OrderBy(contact => contact.Surname).ToList();
            return sortedList;
        }

        /// <summary>
        /// Поиск контактов по фамилии
        /// </summary>
        /// <param name="substring"></param>
        /// <returns></returns>
        public List<Contact> SortList(string substring)
        {
            var findSortedList = from conntact in _contactlist
                where conntact.Surname.StartsWith(substring,
                    StringComparison.OrdinalIgnoreCase)
                orderby conntact.Surname
                select conntact;
            return findSortedList.ToList();
        }

        public List<Contact> BirthData(DateTime date)
        {
            var birthdatedataList = new List<Contact>();
            var ContactList = new List<Contact>();
            ContactList = _contactlist;
            foreach (Contact contact in ContactList)
            {
                if (contact.Date.Month==date.Month && contact.Date.Day==date.Day)
                {
                    birthdatedataList.Add(contact);
                }

            }
            return birthdatedataList;
        }

        public bool Equals(Project other)
        {
            return Equals(_contactlist, other._contactlist);
        }
    }
}