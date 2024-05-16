using H0AGKU_HFT_2023241.Models;
using Microsoft.Toolkit.Mvvm.ComponentModel;
using Microsoft.Toolkit.Mvvm.Input;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace H0AGKU_HFT_2023241.WpfClient
{
    class MainWindowViewModel : ObservableRecipient
    {
        public RestCollection<League> Leagues { get; set; }
        public ICommand CreateLeagueCommand { get; set; }
        public ICommand DeleteLeagueCommand { get; set; }
        public ICommand UpdateLeagueCommand { get; set; }

        private League selectedLeague;
        public League SelectedLeague
        {
            get { return selectedLeague; }
            set
            {
                if (value != null)
                {
                    selectedLeague = new League()
                    {
                        Name = value.Name,
                        Id = value.Id,
                        Country = value.Country,
                        HasVar = value.HasVar,
                        Teams = value.Teams,

                    };
                    OnPropertyChanged();
                    (DeleteLeagueCommand as RelayCommand).NotifyCanExecuteChanged();
                }

            }
        }

        public RestCollection<Player> Players { get; set; }
        public ICommand CreatePlayerCommand { get; set; }
        public ICommand DeletePlayerCommand { get; set; }
        public ICommand UpdatePlayerCommand { get; set; }
        private Player selectedPlayer;
        public Player SelectedPlayer
        {
            get { return selectedPlayer; }
            set
            {
                if (value != null)
                {
                    selectedPlayer = new Player()
                    {
                        Name = value.Name,
                        Id = value.Id,
                        Age = value.Age,
                        PlayerSalary = value.PlayerSalary,
                       
                    };
                    OnPropertyChanged();
                    (DeleteLeagueCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public RestCollection<Team> Teams { get; set; }
        public ICommand CreateTeamCommand { get; set; }
        public ICommand DeleteTeamCommand { get; set; }
        public ICommand UpdateTeamCommand { get; set; }

        private Team selectedTeam;
        public Team SelectedTeam
        {
            get { return selectedTeam; }
            set
            {
                if (value != null)
                {
                    selectedTeam = new Team()
                    {
                        ID = value.ID,
                        Name = value.Name,
                       
                    };
                    OnPropertyChanged();
                    (DeleteLeagueCommand as RelayCommand).NotifyCanExecuteChanged();
                }
            }
        }

        public string AvarageSalary {  get; set; }
        public List<JuniorLeagueInfo> JuniorLeagueInfo { get; set; }
        public List<string> YoungerThan { get; set; }
        public string YoungSalaryWPF { get; set; }
        public int YoungestPlayerAgeWPF { get; set; }


        public static bool IsInDesignMode
        {
            get
            {
                var prop = DesignerProperties.IsInDesignModeProperty;
                return (bool)DependencyPropertyDescriptor.FromProperty(prop, typeof(FrameworkElement)).Metadata.DefaultValue;
            }
        }
        public MainWindowViewModel()
        {
            Leagues = new RestCollection<League>("http://localhost:62823/", "league","hub");
            Players = new RestCollection<Player>("http://localhost:62823/", "player","hub");
            Teams = new RestCollection<Team>("http://localhost:62823/", "team","hub");

            int teamid = 9;
            //AvarageSalary = new RestService("http://localhost:62823/").Get<string>("Info/AvarageSalary/"+teamid).ToString();
            int age = 35;
            //YoungerThan = new RestService("http://localhost:62823/").Get<string>("Info/GetPlayersYoungerThanX"+age);

            YoungestPlayerAgeWPF = new RestService("http://localhost:62823/").GetSingle<int>("Info/GetYoungestPlayerAge/");
            //JuniorLeagueInfo = new RestService("http://localhost:62823/").Get<JuniorLeagueInfo>("JuniorLeague/GetJuniorLeagueInfo/");

            YoungSalaryWPF = new RestService("http://localhost:62823/").GetSingle<int>("Info/GetYoungsterSalaryInfo").ToString();





            CreateLeagueCommand = new RelayCommand(() =>
            {
                Leagues.Add(new League()
                {
                    Name = SelectedLeague.Name,
                    Id = SelectedLeague.Id,
                    Country = SelectedLeague.Country,

                });

            });

            DeleteLeagueCommand = new RelayCommand(() =>
            {
                Leagues.Delete(SelectedLeague.Id);
            },
            () =>
            {
                return SelectedLeague != null;
            });

            UpdateLeagueCommand = new RelayCommand(() =>
            {
                Leagues.Update(SelectedLeague);
            });
            //////////////////////////////////////////
            CreateTeamCommand = new RelayCommand(() =>
            {
                Teams.Add(new Team()
                {
                    ID = SelectedTeam.ID,
                    Name = SelectedTeam.Name,
                                 


                });
            });

            DeleteTeamCommand = new RelayCommand(() =>
            {
                Teams.Delete(SelectedTeam.ID);
            },
                () =>
                {
                    return SelectedTeam != null;
                });

            UpdateTeamCommand = new RelayCommand(() =>
            {
                Teams.Update(SelectedTeam);
            });
            //////////////////////////////////////
            CreatePlayerCommand = new RelayCommand(() =>
            {
                Players.Add(new Player()
                {
                    Name = SelectedPlayer.Name,
                    Id = SelectedPlayer.Id,
                    Age= SelectedPlayer.Age,
                    PlayerSalary= SelectedPlayer.PlayerSalary,

                });
            });

            DeletePlayerCommand = new RelayCommand(() =>
            {
                Players.Delete(SelectedPlayer.Id);
            },
                () =>
                {
                    return SelectedPlayer != null;
                });

            UpdatePlayerCommand = new RelayCommand(() =>
            {
                Players.Update(SelectedPlayer);
            });

            SelectedLeague = new League();
            SelectedTeam = new Team();
            SelectedPlayer = new Player();



        }







    }
}
