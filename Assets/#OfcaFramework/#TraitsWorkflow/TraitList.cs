using System;
using System.Collections.Generic;

namespace OfcaFramework.TraitsWorkflow
{
    public class TraitList<T> : ITraitContainer<T> where T : Trait
    {
        private List<T> traits = new List<T>();

        public event Action<T> OnTraitAdded;
        public event Action<T> OnTraitRemoved;

        public void AddTrait(T trait)
        {
            if (!traits.Contains(trait))
            {
                traits.Add(trait);
                OnTraitAdded?.Invoke(trait);
            }
        }

        public void RemoveTrait(T trait)
        {
            if (traits.Contains(trait))
            {
                traits.Remove(trait);
                OnTraitRemoved?.Invoke(trait);
            }
        }

        public bool HasTrait(T trait)
        {
            return traits.Contains(trait);
        }

        public List<T> GetAllTraits()
        {
            return traits;
        }
    }
}
