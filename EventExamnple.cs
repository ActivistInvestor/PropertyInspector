using Autodesk.AutoCAD.ActivistInvestor;
using Autodesk.AutoCAD.ApplicationServices;
using Autodesk.AutoCAD.EditorInput;
using Autodesk.AutoCAD.Internal.PropertyInspector;
using Autodesk.AutoCAD.Runtime;
using System.Windows.Input;

/// <summary>
/// Example showing how to handle property changed event
/// Use the IACPIEVENTS command to toggle event handler
/// </summary>

public static class EventExamnple
{

   static bool enabled = false;

   /// <summary>
   /// IACPIEVENTS command toggles handling of PropertyChanged event
   /// </summary>
   
   [CommandMethod(nameof(IAcPiEvents))]
   public static void IAcPiEvents()
   {
      enabled ^= true;
      if(enabled)
         PropertyInspector.EventManager.propertyChanged += PropertyInspector_propertyChanged;
      else
         PropertyInspector.EventManager.propertyChanged -= PropertyInspector_propertyChanged;
   }

   private static void PropertyInspector_propertyChanged(object sender, PropertyInspectorEventArgs e)
   {
      IAcPiPropertyIdentifier prop = e.Property as IAcPiPropertyIdentifier;
      if(prop != null)
         Write($"\n<<Property {prop.Name} changed to {prop.ValueAsString}>>");
   }

   static void Write(string msg, params object[] args)
   {
      Document doc = Application.DocumentManager.MdiActiveDocument;
      if(doc == null)
      {
         doc.Editor.WriteMessage(msg, args);
      }
   }

}

