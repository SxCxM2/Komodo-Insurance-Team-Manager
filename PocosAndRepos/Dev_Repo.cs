using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PocosAndRepos
{
    public class Dev_Repo
    {
        private List<Dev> _listOfDevelopers = new List<Dev>();

        public void AddDeveloperToList(Dev developer)
        {
            _listOfDevelopers.Add(developer);
        }

        public List<Dev> GetDeveloperList()
        {
            return _listOfDevelopers;
        }

        public List<Dev> NeedAccess()
        {
            List<Dev> noAccess = new List<Dev>();

            foreach (Dev dev in _listOfDevelopers)
            {
                if (dev.HasAccess == false)
                {
                    noAccess.Add(dev);
                }
            }
            return noAccess;
        }

        public bool UpdateExisitingDeveloperList(int oldId, Dev newDeveloper)
        {
            Dev oldDeveloper = GetDeveloperById(oldId);

            if (oldDeveloper != null)
            {
                oldDeveloper.DevName = newDeveloper.DevName;
                oldDeveloper.HasAccess = newDeveloper.HasAccess;

                return true;
            }
            else
            {
                return false;
            }

        }

        public bool RemoveDeveloperFromList(string devname)
        {
            Dev developer = GetDeveloperByName(devname);

            if (developer == null)
            {
                return false;
            }

            int initalCount = _listOfDevelopers.Count;
            _listOfDevelopers.Remove(developer);

            if (initalCount > _listOfDevelopers.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private Dev GetDeveloperByName(string devname)
        {
            foreach (Dev Developer in _listOfDevelopers)
            {
                if (Developer.DevName == devname.ToLower())
                {
                    return Developer;
                }
            }
            return null;
        }
        public Dev GetDeveloperById(int devId)
        {
            foreach (Dev Developer in _listOfDevelopers)
            {
                if (Developer.IdNumber == devId)
                {
                    return Developer;
                }
            }
            return null;
        }
    }
}
