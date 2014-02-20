using System.Windows;

namespace Listbox_Drag_and_Drop_Tests.Behavior.Implementation
{
    /// <summary>
    /// A contract stating that a viewmodel is a drop destination for the type found in the mvvm paradigm
    /// </summary>
    public interface IMvvmDroppable : IMvvmParadigm
    {
        /// <summary>
        /// Adds the object, includes an index if it is some kind of list we are adding to.
        /// </summary>
        /// <param name="item">The item to insert into this viewmodel</param>
        /// <param name="index">defaults to -1, optional parameter</param>
        void AcceptDropAt(object item, int index = -1);
        /// <summary>
        /// Makes sure that the item attempting entry is the type of viewmodel we are designed to accept
        /// </summary>
        /// <param name="sender">The object's source or host</param>
        /// <param name="e">The event args that should include the object being dragged</param>
        /// <returns></returns>
        bool CheckData(object sender, DragEventArgs e);
    }//end of interface
}//end of namespace