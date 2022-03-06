using System;
using System.Collections.Generic;
using DIO.Series.Interfaces;
using DIO.Series.Models;
using System.Linq;

namespace DIO.Series.Data
{
    public class TVSeriesRepository : IRepository<TVSeries>
    {
        private List<TVSeries> _listTvSeries = new List<TVSeries>();
        private int _nextID = 0;

        public TVSeries GetById(int id)
        {
            int index = GetIndex(id);

            if (index == -1) return null;

            return _listTvSeries[index];
        }

        public List<TVSeries> List()
        {
            return _listTvSeries;
        }

        public void Insert(TVSeries newTvSeries)
        {
            _listTvSeries.Add(newTvSeries);
            _nextID++;
        }

        public void Update(int id, TVSeries newTvSeries)
        {
            int index = GetIndex(id);

            if (index == -1) return;

            _listTvSeries[index] = newTvSeries;
        }

        public void Delete(int id)
        {
            int index = GetIndex(id);

            if (index == -1) return;

            _listTvSeries.RemoveAt(index);
        }

        public int NextID()
        {
            return _nextID;
        }

        public int GetIndex(int id)
        {
            int index = _listTvSeries.FindIndex(tvSeries => id == tvSeries.Id);
            return index;
        }
    }
}
