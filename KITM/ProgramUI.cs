using PocosAndRepos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KITM
{
    class ProgramUI
    {
        private Dev_Repo _developerRepo = new Dev_Repo();

        private DevTeam_Repo _teamRepo = new DevTeam_Repo();

        public void Run()
        {
            SeeDeveloperList();
            Menu();
        }
        private void Menu()
        {
            bool keepRunning = true;
            while (keepRunning)
            {

                Console.WriteLine("Komodo Insurance Manager:\n" +
                    "1. Add New Developer\n" +
                    "2. View All Developers\n" +
                    "3. View All Developer-Teams\n" +
                    "4. Update Existing Developer\n" +
                    "5. Update Existing Developer-Team\n" +
                    "6. Create New Developer-Team\n" +
                    "7. Add Developer to a Team\n" +
                    "8. Need Pluralsight Access\n" +
                    "9. View Team by ID#\n" +
                    "10. Remove a Developer From a Team\n" +
                    "11. Exit");

                string input = Console.ReadLine();

                switch (input)
                {
                    case "1":
                        CreateNewDevloper();
                        break;
                    case "2":
                        DisplayAllDevelopers();
                        break;
                    case "3":
                        DisplayAllDeveloperTeams();
                        break;
                    case "4":
                        UpdateExisitingDeveloper();
                        break;
                    case "5":
                        UpdateExisitingDeveloperTeam();
                        break;
                    case "6":
                        CreateNewDeveloperTeam();
                        break;
                    case "7":
                        AddDeveloperToTeam();
                        break;
                    case "8":
                        NeedPluralsightAccess();
                        break;
                    case "9":
                        ViewTeamByTeamId();
                        break;
                    case "10":
                        RemoveADeveloperFromATeam();
                        break;
                    case "11":
                        Console.WriteLine("Goodbye!");
                        keepRunning = false;
                        break;
                    default:
                        Console.WriteLine("Please enter a valid number.");
                        break;
                }

                Console.WriteLine("Press Any Key To Continue.");
                Console.ReadKey();
                Console.Clear();
            }
        }
        private void CreateNewDevloper()
        {
            Console.Clear();
            Dev newDeveloper = new Dev();

            Console.WriteLine("Enter the first & last name for the new developer:");
            newDeveloper.DevName = Console.ReadLine();

            Console.WriteLine("Enter Developer ID#:");
            string idnumberasstring = Console.ReadLine();
            newDeveloper.IdNumber = int.Parse(idnumberasstring);

            Console.WriteLine("Does this developer have access to Pluralsight? (y/n)");
            string hasaccess = Console.ReadLine().ToLower();

            if (hasaccess == "y")
            {
                newDeveloper.HasAccess = true;
            }
            else
            {
                newDeveloper.HasAccess = false;
            }


            _developerRepo.AddDeveloperToList(newDeveloper);
        }

        public void DisplayAllDevelopers()
        {
            Console.Clear();

            List<Dev> listOfDevelopers = _developerRepo.GetDeveloperList();

            foreach (Dev deveopler in listOfDevelopers)
            {
                Console.WriteLine($"Developer:{deveopler.DevName}\n" +
                    $"ID#:{deveopler.IdNumber}\n" +
                    $"Has access to Pluralsight:{deveopler.HasAccess}");
            }

        }

        public void DisplayAllDeveloperTeams()
        {
            Console.Clear();

            List<DevTeam> listofTeams = _teamRepo.GetTeamList();

            foreach (DevTeam team in listofTeams)
            {
                Console.WriteLine($"Team Name: {team.TeamName}\n" +
                    $"Team ID#:{team.TeamIdNumber}\n");
            }
        }

        
        public void UpdateExisitingDeveloper()
        {

            DisplayAllDevelopers();

            Console.WriteLine("Enter the ID# of the developer you'd like to update.");
            int oldDeveloper = int.Parse(Console.ReadLine());

            Dev newDeveloper = new Dev();

            Console.WriteLine("Enter the first & last name for the developer you are updating:");
            newDeveloper.DevName = Console.ReadLine();

            Console.WriteLine("Does this developer have access to Pluralsight? (y/n)");
            string hasaccess = Console.ReadLine().ToLower();

            if (hasaccess == "y")
            {
                newDeveloper.HasAccess = true;
            }
            else
            {
                newDeveloper.HasAccess = false;
            }

            bool wasUpdated = _developerRepo.UpdateExisitingDeveloperList(oldDeveloper, newDeveloper);
            if (wasUpdated)
            {
                Console.WriteLine("Developer successfully updated!");
            }
            else
            {
                Console.WriteLine("Could not update developer.");
            }
        }

        public void UpdateExisitingDeveloperTeam()
        {
            DisplayAllDeveloperTeams();

            Console.WriteLine("Enter team ID# that you'd like to update.");
            int oldId = int.Parse(Console.ReadLine());

            DevTeam newTeam = new DevTeam();

            Console.WriteLine("Enter the new name of the developer team:");
            newTeam.TeamName = Console.ReadLine();


            bool wasUpdated = _teamRepo.UpdateExisitingTeamList(oldId, newTeam);
            if (wasUpdated)
            {
                Console.WriteLine("Team successfully updated!");
            }
            else
            {
                Console.WriteLine("Could not update Team.");
            }
        }

        public void CreateNewDeveloperTeam()
        {
            Console.Clear();
            DevTeam newDeveloperTeam = new DevTeam();

            Console.WriteLine("Enter the name of the new developer team:");
            newDeveloperTeam.TeamName = Console.ReadLine();

            Console.WriteLine("Enter the developer team ID#:");
            string teamidnumberasstring = Console.ReadLine();
            newDeveloperTeam.TeamIdNumber = int.Parse(teamidnumberasstring);

            newDeveloperTeam.TeamMembers = new List<Dev>();

            _teamRepo.AddDevTeamToList(newDeveloperTeam);
        }

        public void AddDeveloperToTeam()
        {
            Console.Clear();
            DisplayAllDeveloperTeams();

            Console.WriteLine("Enter the Team ID# that you would like add a developer to:");
            int teamID = int.Parse(Console.ReadLine());

            Console.Clear();

            Console.WriteLine("Enter the ID# of the developer you would like to add to the team.");
            int IdNumber = int.Parse(Console.ReadLine());

            Dev addDeveloper = _developerRepo.GetDeveloperById(IdNumber);

            bool wasUpdated = _teamRepo.AddingEmployeeToList(teamID, addDeveloper);
            if (wasUpdated)
            {
                Console.WriteLine("Team successfully updated!");
            }
            else
            {
                Console.WriteLine("Could not update Team.");
            }
        }

        public void NeedPluralsightAccess()
        {
            Console.Clear();

            List<Dev> needAccess = _developerRepo.NeedAccess();

            foreach (Dev devName in needAccess)
            {
                Console.WriteLine("{0}", devName.DevName);
            }
        }
        public void ViewTeamByTeamId()
        {
            Console.WriteLine("Please enter Team ID# to view members of that team.");
            string input = Console.ReadLine();
            int teamid;
            Int32.TryParse(input, out teamid);


            DevTeam devTeamToView = _teamRepo.GetTeamById(teamid);


            foreach (Dev dev in devTeamToView.TeamMembers)
            {
                Console.WriteLine($"{dev.DevName}");
            }

        }

        public void RemoveADeveloperFromATeam()
        {
            Console.Clear();
            DisplayAllDeveloperTeams();

            Console.WriteLine("Enter the Team ID# that you would like remove a developer from:");
            int teamID = int.Parse(Console.ReadLine());

            Console.Clear();

            Console.WriteLine("Enter the ID# of the developer that you would like to remove from the team.");
            int IdNumber = int.Parse(Console.ReadLine());

            Dev removeDeveloper = _developerRepo.GetDeveloperById(IdNumber);

            bool wasUpdated = _teamRepo.RemoveDeveloperFromTeam(teamID, removeDeveloper);
            if (wasUpdated)
            {
                Console.WriteLine("Team successfully updated!");
            }
            else
            {
                Console.WriteLine("Could not update Team.");
            }
        }


        private void SeeDeveloperList()
        {
            Dev someOne = new Dev("Some One", 222, false);
            Dev someOtherOne= new Dev("Some OtherOne", 333, true);
            Dev yetAnotherOne = new Dev("YetAnother One", 444, false);

            List<Dev> teamOrange = new List<Dev>();
            teamOrange.Add(someOne);
            teamOrange.Add(someOtherOne);
            teamOrange.Add(yetAnotherOne);

            List<Dev> teamBlack = new List<Dev>();
            teamBlack.Add(someOne);
            teamBlack.Add(someOtherOne);

            DevTeam orangeTeam = new DevTeam("Orange Team", 777, teamOrange);
            DevTeam blackTeam = new DevTeam("Black Team", 999, teamBlack);
            _teamRepo.AddDevTeamToList(orangeTeam);
            _teamRepo.AddDevTeamToList(blackTeam);

            _developerRepo.AddDeveloperToList(someOne);
            _developerRepo.AddDeveloperToList(someOtherOne);
            _developerRepo.AddDeveloperToList(yetAnotherOne);
        }

    }
}
