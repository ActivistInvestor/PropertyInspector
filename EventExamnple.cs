using System;
using Autodesk.AutoCAD.Runtime;
using Autodesk.AutoCAD.ApplicationServices;

// Alias is required because the PropertyInspector
// class has the same name as the cohtaining namespace:

using AcPi = Autodesk.AutoCAD.Internal.PropertyInspector;

/// <summary>
/// Example showing how to handle property changed event
/// Use the IACPIEVENTS command to toggle event handler
/// </summary>

namespace PropertyInspectorExamples
{
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
         var events = AcPi.PropertyInspector.EventManager;
         if(enabled)
            events.propertyChanged += PropertyInspector_propertyChanged;
         else
            events.propertyChanged -= PropertyInspector_propertyChanged;
      }

      private static void PropertyInspector_propertyChanged(object sender, AcPi.PropertyInspectorEventArgs e)
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

}