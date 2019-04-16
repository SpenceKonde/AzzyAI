// PvpTactCollection.cs
//
// Programmed by Machiavellian of iRO Chaos
//
// Description:
// This file contains code for the PvpTactCollection class, which implements
// the generic interface ICollection<T>.

using System;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Collections;
using System.Collections.Generic;


namespace AzzyAIConfig
{
    class PvpTactCollection : System.Collections.Generic.ICollection<PvpTact>
    {
        PvpTact[] _items = new PvpTact[0];

        public PvpTactCollection()
        {
        }

        public PvpTactCollection(PvpTact[] items)
        {
            // Set the array of tactics
            _items = items;
        }

        public PvpTactCollection(PvpTact[] items, bool readOnly)
        {
            // Set the array of tactics
            _items = items;

            // Set the collection as read only
            _readOnly = readOnly;
        }

        public void Add(PvpTact item)
        {
            // Check if the collection is read only
            if (_readOnly)
            {
                // Throw a new exception
                throw new Exception("The collection is read-only.");
            }
            // If the collection is not read only
            else
            {
                // Create a new tactics array
                PvpTact[] old = new PvpTact[_items.Length];

                // Copy the old tactics array to the new one
                _items.CopyTo(old, 0);

                // Create a new tactics array with one extra slot
                _items = new PvpTact[old.Length + 1];

                // Copy the old tactics array to the new one
                old.CopyTo(_items, 0);

                // Set the last object in the array to the new tactic
                _items[old.Length] = item;

                // Sort the array
                Array.Sort(_items);
            }
        }

        public void Clear()
        {
            // Check if the collection is read only
            if (_readOnly)
            {
                // Throw a new exception
                throw new Exception("The collection is read-only.");
            }
            // If the collection is not read only
            else
            {
                // Clear the tactics array
                _items = new PvpTact[0];
            }
        }

        public bool Contains(PvpTact item)
        {
            // Check if the tactics array has more than one object
            if (_items.Length > 0)
            {
                // Create a new tactics array
                PvpTact[] search = new PvpTact[_items.Length];

                // Copy the old tactics array to the new one
                _items.CopyTo(search, 0);

                // Run through all the tactics in the new array
                foreach (PvpTact t in search)
                {
                    // Check if the current tactic is equal to item
                    if (t == item)
                    {
                        // Return true
                        return true;
                    }
                }
            }

            // Return false
            return false;
        }

        public void CopyTo(PvpTact[] array, int arrayIndex)
        {
            // Copy the tactics array to array starting at arrayIndex
            _items.CopyTo(array, arrayIndex);
        }

        public int Count
        {
            get { return _items.Length; }
        }

        bool _readOnly = false;
        public bool IsReadOnly
        {
            get { return _readOnly; }
        }

        public bool Remove(PvpTact item)
        {
            // Check if the collection is read only
            if (_readOnly)
            {
                // Throw a new exception
                throw new Exception("The collection is read-only.");
            }
            // If the collection is not read only and contains item
            else if (Contains(item))
            {
                // Create a new tactics array
                PvpTact[] old = new PvpTact[_items.Length];

                // Copy the old tactics array to the new one
                _items.CopyTo(old, 0);

                // Search for the item and replace it with the last tactic in the array
                int i = 0;
                while (old[i] != item)
                {
                    i++;
                    if (old[i] == item)
                    {
                        old[i] = old[old.Length - 1];
                    }
                }

                // Create a new tactics array with one less slot than the old one
                _items = new PvpTact[old.Length - 1];

                // Run through all the slots in the new array
                for (i = 0; i < _items.Length; i++)
                {
                    // Set the current slot to the old tactic
                    _items[i] = old[i];
                }

                // Sort the new array
                Array.Sort(_items);

                // Return true
                return true;
            }

            // Return false
            return false;
        }

        public IEnumerator<PvpTact> GetEnumerator()
        {
            // Return the enumerator for this collection
            return new PvpTactEnumerator(_items);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            // Throw a not implemented exception
            throw new NotImplementedException();
        }
    }
}