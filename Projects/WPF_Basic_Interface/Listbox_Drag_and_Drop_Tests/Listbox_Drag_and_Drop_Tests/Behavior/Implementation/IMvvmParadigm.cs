using System;

namespace Listbox_Drag_and_Drop_Tests.Behavior.Implementation
{
    /// <summary>
    /// An abstraction to state that the following classes after this will try to conform to the IMvvm Pattern
    /// </summary>
    public interface IMvvmParadigm
    {
        /// <summary>
        /// The data-type to represent the class
        /// </summary>
        Type DataType { get; set; }
    }//end of interface
}//end of namespace