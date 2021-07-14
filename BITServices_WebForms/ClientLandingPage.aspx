<%@ Page Title="Client Home Page" Language="C#" MasterPageFile="~/LoggedInMaster.Master" AutoEventWireup="true" CodeBehind="ClientLandingPage.aspx.cs" Inherits="BITServices_WebForms.ClientLandingPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="w3-content container">
        <div class="row">
            <div class="col-12">
                <h2 style="display: inline;">Active Job Requests</h2>
                <asp:TextBox runat="server" placeholder="Search" ID="txtActiveJobSearch" CssClass="GridViewSearch"/>
            </div>
        </div>
        <div class="row">
            <div class="col-12">
                <asp:GridView class="table table-striped table-bordered" ID="gvActiveJobRequests" runat="server" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" AllowSorting="True" >
                    <Columns>
                       <asp:TemplateField HeaderText="Select">
                            <ItemTemplate>
                                <asp:CheckBox runat="server" ID="chkSelected"/>
                             </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="JobDate" HeaderText="Date" DataFormatString="{0:d}" />
                        <asp:BoundField DataField="JobStartTime" HeaderText="Start Time" />
                        <asp:BoundField DataField="JobStreet" HeaderText="Street" />
                        <asp:BoundField DataField="JobSuburb" HeaderText="Suburb" />
                        <asp:BoundField DataField="JobState" HeaderText="State" />
                        <asp:BoundField DataField="JobPostCode" HeaderText="Post Code" />
                        <asp:BoundField DataField="JobUrgency" HeaderText="Urgency" />
                        <asp:BoundField DataField="SkillName" HeaderText="Skill" />
                    </Columns>
                    <EmptyDataTemplate>No Jobs Found</EmptyDataTemplate>
                </asp:GridView>
                 <script>
                     $(document).ready(function () {        //jquery code for filtering table
                         $("#MainContent_txtActiveJobSearch").on("keyup", function () {
                             var value = $(this).val().toLowerCase();
                             $("#MainContent_gvActiveJobRequests tr:not(:first-child)").filter(function () {
                                 $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
                             });
                         });
                     });
                </script> 
            </div>
        </div>
        <div class="row GridViewButtons">
            <div class="col-12">
                <div class="btn-group" role="group">
                    <button class="btn btn-primary" data-target="#newJobModal" data-toggle="modal">Create New Job Request</button>
                    <button class="btn btn-danger" data-target="#deleteJobModal" data-toggle="modal" onclick="setDeleteMessage()">Cancel Job</button>
                </div>

                <div id="newJobModal" class="modal fade" tabindex="-1" role="dialog" data-backdrop="false">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Create New Job Request</h4>
                            </div>
                            <div class="modal-body">
                                <div class="form-group">
                                    <label for="jobDate">Job Date:</label>
                                    <input class="form-control" type="date" name="jobDate" id="dateJob" runat="server" required />
                                </div>
                                <div class="form-group">
                                    <label for="jobTime">Job Time:</label>
                                    <input class="form-control" type="time" name="jobTime" id="timeJob" runat="server" required />
                                </div>
                                <div class="form-group">
                                    <label>Job Skill:</label>
                                    <asp:DropDownList runat="server" CssClass="form-control" ID="ddlSkill" />
                                </div>
                                <div class="form-group">
                                    <label for="jobUrgency">Job Urgency:</label>
                                    <select name="urgency" runat="server" id="ddlUrgency" class="form-control" required >
                                        <option value="Immediate">Immediate</option>
                                        <option value="High">High</option>
                                        <option value="Medium">Medium</option>
                                        <option value="Low">Low</option>
                                    </select>
                                </div>
                                <div class="form-group">
                                    <label for="jobStreet">Job Street:</label>
                                    <input class="form-control" type="text" placeholder="Street Name" name="jobStreet" id="txtStreet" runat="server" required maxlength="50" />
                                </div>
                                <div class="form-group">
                                    <label for="jobSuburb">Job Suburb:</label>
                                    <input class="form-control" type="text" placeholder="Suburb" name="jobSuburb" id="txtSuburb" runat="server" required maxlength="30"/>
                                </div>
                                <div class="form-group">
                                    <label for="jobState">Job State:</label>
                                    <select name="jobState" runat="server" id="ddlState" class="form-control" required>
                                        <option value="NSW">NSW</option>
                                        <option value="VIC">Victoria</option>
                                        <option value="ACT">ACT</option>
                                        <option value="QLD">Queensland</option>
                                        <option value="TAS">Tasmania</option>
                                        <option value="SA">South Australia</option>
                                        <option value="NT">Northern Territory</option>
                                        <option value="WA">Western Australia</option>
                                    </select>
                                </div>
                                <div class="form-group">
                                    <label for="jobPostCode">Job Post Code:</label>
                                    <input class="form-control" type="text" placeholder="Post Code" name="jobPostCode" id="txtPostCode" runat="server" required maxlength="4" />
                                </div>
                                <div class="form-group">
                                    <label for="jobProblem">Job Problem:</label>
                                    <input class="form-control" type="text" placeholder="Problem" name="jobPostCode" id="txtJobProblem" runat="server" required>
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button CssClass="btn btn-primary" ID="btnCreateJob" runat="server" Text="Create Job" method="post" OnClick="btnCreateJob_Click"/>
                                <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancel</button>
                            </div>
                        </div>
                    </div>
                </div>

                <div id="deleteJobModal" class="modal fade" tabindex="-1" role="dialog" data-backdrop="false">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-body">
                                <p id="cancelMessage" />
                                <script>
                                    function setDeleteMessage() {
                                        var output = document.querySelector("#cancelMessage");
                                        var confirmButton = document.querySelector("#MainContent_btnCancelJob");
                                        confirmButton.style.display = "inline-block";
                                        var checkBoxList = document.querySelectorAll('input[type="checkbox"]');
                                        var checkedCount = 0;

                                        for (i = 0; i < checkBoxList.length; i++) {
                                            if (checkBoxList[i].checked) {
                                                checkedCount++;
                                            }
                                        }

                                        switch (checkedCount) {
                                            case 0:
                                                output.innerHTML = "No job has been selected.";
                                                confirmButton.style.display = "none";
                                                break;
                                            case 1:
                                                output.innerHTML = "Do you want to cancel the selected job?";
                                                confirmButton.value = "Cancel Job";
                                                break;
                                            default:
                                                output.innerHTML = "Do you want to cancel the selected jobs?";
                                                confirmButton.value = "Cancel Jobs";
                                        }
                                    }              
                                </script>
                            </div>
                            <div class="modal-footer">
                                <asp:Button runat="server" CssClass="btn btn-primary" ID="btnCancelJob" method="post" OnClick="btnCancelJob_Click" UseSubmitBehavior="false" Text="OK"/>
                                <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancel</button>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
        <div class="row" style="margin-top: 50px;">
            <div class="col-12">
                <h2 style="display:inline;">All Jobs</h2>
                <asp:TextBox runat="server" placeholder="Search" ID="txtAllJobSearch" CssClass="GridViewSearch" />
            </div>
        </div>
        <div class="row">
            <div class="col-12">
                <asp:GridView class="table table-striped table-bordered" ID="gvAllJobs" runat="server" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="JobDate" HeaderText="Date" DataFormatString="{0:d}"/>
                        <asp:BoundField DataField="JobStartTime" HeaderText="Start Time" />
                        <asp:BoundField DataField="JobStreet" HeaderText="Street" />
                        <asp:BoundField DataField="JobSuburb" HeaderText="Suburb" />
                        <asp:BoundField DataField="JobState" HeaderText="State" />
                        <asp:BoundField DataField="JobPostCode" HeaderText="Post Code" />
                        <asp:BoundField DataField="JobUrgency" HeaderText="Urgency" />
                        <asp:BoundField DataField="SkillName" HeaderText="Skill" />
                        <asp:BoundField DataField="JobStatus" HeaderText="Status" />
                    </Columns>
                    <EmptyDataTemplate>No Jobs Found</EmptyDataTemplate>
                </asp:GridView>
                <script>
                    $(document).ready(function () {
                        $("#MainContent_txtAllJobSearch").on("keyup", function () {
                            var value = $(this).val().toLowerCase();
                            $("#MainContent_gvAllJobs tr:not(:first-child)").filter(function () {
                                $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
                            });
                        });
                    });
                </script> 
            </div>
        </div>
    </div>
</asp:Content>
