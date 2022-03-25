﻿namespace CarRental.Core.CrossCuttingConcerns.Caching
{
    public interface ICacheManager
    {
        T Get<T> (string key);
        void Add(string key, object value, int duration);
        void Remove(string key);
        bool IsAdd(string key);
        void RemoveByPattern(string pattern);
    }
}