Option Explicit

'Selection ok, crash later. Possible dom issue failure line 39

Private Sub subCreateIGES()

' Objects
Dim objSel As Selection
Dim objSelLB 'As Object
Dim objTgtDoc As PartDocument
Dim objTgt As Part
Dim objTgtSel As Selection

' Array
Dim InputObjectType(0)

' String
Dim Status As String
Dim strPartName As String

' Integer
Dim intCounter As Integer
Dim Num_Surfaces As Integer

Dim Surface()

Set objSel = CATIA.ActiveDocument.Selection
Set objSelLB = objSel

InputObjectType(0) = "Face"

Status = objSelLB.SelectElement3(InputObjectType, "Select points", True, CATMultiSelTriggWhenUserValidatesSelection, False)

If Status = "Cancel" Then Exit Sub
Num_Surfaces = objSelLB.Count2
ReDim Preserve Surface(Num_Surfaces)

For intCounter = 1 To Num_Surfaces
'Surface(intCounter) = objSelLB.Item(intCounter).Value
Surface(intCounter) = objSelLB.Selection(intCounter).Value
Next


For intCounter = 1 To objSelLB.Count2
objSelLB.Clear
objSelLB.Add (Surface(intCounter))
objSelLB.Copy
Set objTgtDoc = CATIA.Documents.Add("Part")
Set objTgt = objTgtDoc.Part
Set objTgtSel = objTgtDoc.Selection
Set objTgtDoc = CATIA.ActiveDocument

' Sets and Pastes in Target file as result
objTgtSel.Clear
objTgtSel.Add objTgt.Bodies.Item("PartBody")
objTgtSel.PasteSpecial ("CATPrtResult")

' Creates IGES file
CATIA.DisplayFileAlerts = False
objTgtDoc.ExportData "P:\Temp\IGES_" & intCounter & ".igs", "igs"
CATIA.DisplayFileAlerts = True

objTgtDoc.Close

Next intCounter

End Sub
