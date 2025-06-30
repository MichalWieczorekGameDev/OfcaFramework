using System;
using System.Collections.Generic;

namespace OfcaFramework.TraitsWorkflow
{
    public interface ITraitContainer<T> where T : Trait
    {
        event Action<T> OnTraitAdded;
        event Action<T> OnTraitRemoved;

        void AddTrait(T trait);
        void RemoveTrait(T trait);
        bool HasTrait(T trait);
        List<T> GetAllTraits();
    }
}
