﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using WowUp.WPF.Entities;
using WowUp.WPF.Repositories.Base;
using WowUp.WPF.Repositories.Contracts;

namespace WowUp.WPF.Repositories
{
    public class AddonRepository : BaseRepository<Addon>, IAddonRepository
    {
        public bool AddItem(Addon item)
        {
            lock (_collisionLock)
            {
                item.UpdatedAt = DateTime.UtcNow;

                if (item.Id != 0)
                {
                    _database.Update(item);
                }
                else
                {
                    _database.Insert(item);
                }
            }

            return true;
        }

        public bool UpdateItem(Addon item)
        {
            lock (_collisionLock)
            {
                item.UpdatedAt = DateTime.UtcNow;

                if (item.Id != 0)
                {
                    _database.Update(item);
                }
                else
                {
                    _database.Insert(item);
                }
            }

            return true;
        }

        public bool DeleteItem(string id)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Addon> Query(Func<TableQuery<Addon>, TableQuery<Addon>> action)
        {
            lock (_collisionLock)
            {
                var query = action.Invoke(_database.Table<Addon>());
                return query.AsEnumerable();
            }
        }

        public Addon Query(Func<TableQuery<Addon>, Addon> action)
        {
            lock (_collisionLock)
            {
                return action.Invoke(_database.Table<Addon>());
            }
        }

        public bool AddItems(IEnumerable<Addon> items)
        {
            lock (_collisionLock)
            {
                foreach (var item in items)
                {
                    if (item.Id != 0)
                    {
                        _database.Update(item);
                    }
                    else
                    {
                        _database.Insert(item);
                    }
                }
            }

            return true;
        }

        public bool SaveItems(IEnumerable<Addon> items)
        {
            lock (_collisionLock)
            {
                foreach (var item in items)
                {
                    if (item.Id != 0)
                    {
                        _database.Update(item);
                    }
                    else
                    {
                        _database.Insert(item);
                    }
                }
            }

            return true;
        }
    }
}
