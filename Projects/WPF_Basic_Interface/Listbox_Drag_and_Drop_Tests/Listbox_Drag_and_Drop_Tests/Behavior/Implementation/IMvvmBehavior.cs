using System.Windows.Interactivity;

namespace Listbox_Drag_and_Drop_Tests.Behavior.Implementation
{
    /// <summary>
    /// This is a check, abstraction where our behaviors have to validate if their associated object have implemented IMvvmParadigm
    /// </summary>
    public interface IMvvmBehavior : IAttachedObject
    {
        /// <summary>
        /// Just a check method to see if we can effectively attatch to an object that is or is not IMvvmParadigm
        /// </summary>
        /// <returns>True if the Associated object of the behavior's datacontex implements the IMvvmParadigm interface</returns>
        bool IsAssociatedObjectMvvm();
    }//end of interface
}//end of class