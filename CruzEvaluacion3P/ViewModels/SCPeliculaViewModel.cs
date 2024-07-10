using CruzEvaluacion3P.Models;
using CruzEvaluacion3P.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace CruzEvaluacion3P.ViewModels
{
    public class SCPeliculaViewModel : INotifyPropertyChanged
    { 
        public event PropertyChangedEventHandler PropertyChanged;

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        public SCPeliculaViewModel()
        {
            ChosenDate = DateTime.Now;
        }
        private DateTime dateTime;
        public DateTime ChosenDate
        {
            get { return dateTime; }
            set
            {
                if (value != dateTime)
                {
                    dateTime = value;
                    NotifyPropertyChanged();
                }
                _ = GetPictureOfTheDay(dateTime);
            }
        }
        private string title;
        public string Title
        {
            get { return title; }
            set
            {
                if (value != title)
                {
                    title = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private Uri imageUri;
        public Uri ImageURI
        {
            get { return imageUri; }
            set
            {
                if (imageUri != value)
                {
                    imageUri = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private string didactic;
        public string Didactic
        {
            get { return didactic; }
            set
            {
                if (didactic != value)
                {
                    didactic = value;
                    NotifyPropertyChanged();
                }
            }
        }
        private SCPeliculaService service;
        public SCPeliculaService Service
        {
            get
            {
                if (service == null)
                {
                    service = new SCPeliculaService();
                }
                return service;
            }
        }
        private async Task GetPictureOfTheDay(DateTime day)
        {
            SCPelicula dto = await Service.GetMovie(day);
            if (dto == null)
            {
                ImageURI = new Uri("https://api.themoviedb.org/3/movie/157336?api_key=18d343172084ddeea28efad6b2ddf9e6&append_to_response=videos,images");
                Didactic = "";
                Title = "Intenta con otra fecha";
            }
            else
            {
                ImageURI = new Uri(dto.title);
                Didactic = dto.homepage;
                Title = dto.title;
            }
        }
    }
}
