Option Explicit

Sub CATMain()
  'no error but not working
  
  
Dim productDocument1 As ProductDocument
Set productDocument1 = CATIA.ActiveDocument
Dim documents1 As Documents
Set documents1 = CATIA.Documents
Dim partDocument1 As PartDocument
Set partDocument1 = documents1.Item(2)
Dim part1 As Part
Dim opart As Part
Set opart = partDocument1.Part
Dim reference1 As Reference
Dim oHsf As HybridShapeFactory
Set oHsf = opart.HybridShapeFactory
Dim InputObject(0)
Dim oCentre 'As Selection
Dim status
Dim oTemp 'As Item
Dim oRef As Reference
Dim oHb
Dim oPoint

InputObject(0) = "Edge"
            Set oCentre = CATIA.ActiveDocument.Selection 'the method current filter failed
status = oCentre.SelectElement2(InputObject, "Select Circle", False)
              Set oTemp = oCentre.Item(1)                           'the method parent failed
Set oRef = oTemp.Reference
Set oPoint = oHsf.AddNewPointCenter(oRef)
Set oHb = opart.HybridBodies.Add()
oPoint.Compute
oHb.AppendHybridShape oPoint

End Sub
