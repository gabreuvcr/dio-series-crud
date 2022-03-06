using System;
using DIO.Series.Enums;

namespace DIO.Series.Models
{
    public class TVSeries : BaseEntity
    {
        private Genre Genre { get; set; }
        public string Title { get; private set; }
        private string Description { get; set; }
        private int Year { get; set; }

        public TVSeries(int id, Genre genre, string title, string description, int year)
        {
            base.Id = id;
            this.Genre = genre;
            this.Title = title;
            this.Description = description;
            this.Year = year;
        }

        public override string ToString()
        {
            return $"Genre: {this.Genre}" + Environment.NewLine +
                $"Title: {this.Title}" + Environment.NewLine +
                $"Description: {this.Description}" + Environment.NewLine +
                $"Start year: {this.Year}";
        }
    }
}
