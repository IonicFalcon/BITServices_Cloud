<%@ Page Title="Staff Home Page" Language="C#" MasterPageFile="~/LoggedInMaster.Master" AutoEventWireup="true" CodeBehind="StaffLandingPage.aspx.cs" Inherits="BITServices_WebForms.StaffLandingPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="w3-content container">
        <div class="row">
            <div class="col-12">
                <h2 style="display: inline;">Jobs for Assignment</h2>
                <asp:TextBox runat="server" placeholder="Search" ID="txtAvaliableJobSearch" CssClass="GridViewSearch"/>
            </div>
        </div>
        <div class="row">
            <div class="col-12">
                <asp:GridView runat="server" class="table table-striped table-bordered" ID="gvAvaliableJobRequests" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" AllowSorting="true" OnRowCommand="gvAvaliableJobRequests_RowCommand">
                    <Columns>
                        <asp:TemplateField HeaderText="Assign">
                            <ItemTemplate>
                                <asp:Button ID="btnAssignJob" runat="server" CssClass="btn btn-primary AssignmentButton"  Text="Assign" CausesValidation="false" AutoPostback="false" CommandName="Assign" CommandArgument="<%#Container.DataItemIndex %>" OnClientClick="OpenAssignmentModal()"/>
                                <script>
                                    function OpenAssignmentModal() {
                                        $("#assignJobModal").modal("show");
                                    }
                                </script>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="JobStatus" HeaderText="Job Status" />
                        <asp:BoundField DataField="JobDate" HeaderText="Date"  DataFormatString="{0:d}"/>
                        <asp:BoundField DataField="JobStartTime" HeaderText="Start Time" DataFormatString="{0:g}"/>
                        <asp:BoundField DataField="ClientID" HeaderText="Client ID" />
                        <asp:BoundField DataField="JobStreet" HeaderText="Street" />
                        <asp:BoundField DataField="JobSuburb" HeaderText="Suburb" />
                        <asp:BoundField DataField="JobState" HeaderText="State" />
                        <asp:BoundField DataField="JobPostCode" HeaderText="Post Code" />
                        <asp:BoundField DataField="JobUrgency" HeaderText="Urgency" />
                        <asp:BoundField DataField="SkillName" HeaderText="Skill" />
                        <asp:BoundField DataField="JobDetails" HeaderText="Details" />
                    </Columns>
                    <EmptyDataTemplate>No Jobs Found</EmptyDataTemplate>
                </asp:GridView>
                <script>
                    $(document).ready(function () {
                        $("#MainContent_txtAvaliableJobSearch").on("keyup", function () {
                            var value = $(this).val().toLowerCase();
                            $("#MainContent_gvAvaliableJobRequests tr:not(:first-child)").filter(function () {
                                $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1);
                            });
                        });
                    });
                    
                </script>

                <div id="assignJobModal" class="modal fade" tabindex="-1" role="dialog" data-backdrop="false">
                    <div class="modal-dialog modal-lg" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Assign Job</h4>
                            </div>
                            <div class="modal-body">
                                <asp:UpdatePanel runat="server" ID="updateAssign">
                                    <ContentTemplate>
                                        <div class="container-fluid">
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <label for="jobStatus">Job Status</label>
                                                        <input class="form-control" type="text" name="jobStatus" id="txtStatus" readonly runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <label for="jobDate">Date</label>
                                                        <input class="form-control" type="text" name="jobDate" id="txtDate" readonly runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <label for="jobStartTime">Start Time</label>
                                                        <input class="form-control" type="text" name="jobStartTime" id="txtStartTime" readonly runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <label for="jobClient">Client ID</label>
                                                        <input class="form-control" type="text" name="jobClient" id="txtClient" readonly runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <label for="jobStreet">Street</label>
                                                        <input class="form-control" type="text" name="jobStreet" id="txtStreet" readonly runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <label for="jobSuburb">Suburb</label>
                                                        <input class="form-control" type="text" name="jobSuburb" id="txtSuburb" readonly runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <label for="jobState">State</label>
                                                        <input class="form-control" type="text" name="jobState" id="txtState" readonly runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <label for="jobPostCode">Post Code</label>
                                                        <input class="form-control" type="text" name="jobPostCode" id="txtPostCode" readonly runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <label for="jobUrgency">Urgency</label>
                                                        <input class="form-control" type="text" name="jobUrgency" id="txtUrgency" readonly runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <label for="jobSkill">Skill</label>
                                                        <input class="form-control" type="text" name="jobSkill" id="txtSkill" readonly runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-12">
                                                    <div class="form-group" style="text-align: center;">
                                                        <label for="jobProblem">Problem</label>
                                                        <input class="form-control" type="text" name="jobProblem" id="txtProblem" readonly runat="server" style="display: inline-block;" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row" style="margin-top: 25px;">
                                                <div class="col-lg-12">
                                                    <div class="form-group">
                                                        <asp:GridView class="table table-striped table-bordered" ID="gvAssignContractors" runat="server" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" AllowSorting="true">
                                                            <Columns>
                                                                <asp:TemplateField HeaderText="Select">
                                                                    <ItemTemplate>
                                                                        <asp:RadioButton id="radSelected" GroupName="AssignableContractors" runat="server" />
                                                                    </ItemTemplate>
                                                                </asp:TemplateField>
                                                                <asp:BoundField DataField="Contractor_ID" HeaderText="Contractor ID" />
                                                                <asp:BoundField DataField="FirstName" HeaderText="First Name" />
                                                                <asp:BoundField DataField="LastName" HeaderText="Last Name" />
                                                                <asp:BoundField DataField="State" HeaderText="State" />
                                                                <asp:BoundField DataField="Email" HeaderText="Email" />
                                                                <asp:BoundField DataField="Rating" HeaderText="Rating" />
                                                            </Columns>
                                                            <EmptyDataTemplate>No Contractors Found</EmptyDataTemplate>
                                                        </asp:GridView>
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="gvAvaliableJobRequests" EventName="RowCommand" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                            <div class="modal-footer">
                                <asp:Button CssClass="btn btn-primary" ID="btnAssignContractor" runat="server" Text="Assign Job" method="post" OnClick="btnAssignContractor_Click" />
                                <button class="btn btn-secondary" type="button" data-dismiss="modal">Cancel</button>
                            </div>
                        </div>
                    </div>
                </div>

            </div>
        </div>
        <div class="row" style="margin-top: 50px;">
            <div class="col-12">
                <h2 style="display: inline;">Jobs for Verification</h2>
                <asp:TextBox runat="server" placeholder="Search" ID="txtActiveJobSearch" CssClass="GridViewSearch" />
            </div>
        </div>
        <div class="row">
            <div class="col-12">
                <asp:GridView runat="server" class="table table-striped table-bordered" ID="gvActiveJobRequests" OnRowCommand="gvActiveJobRequests_RowCommand"  ShowHeaderWhenEmpty="true" AutoGenerateColumns="false" AllowSorting="true">
                    <Columns>
                        <asp:TemplateField HeaderText="Verify Complete">
                            <ItemTemplate>
                                <asp:Button ID="btnVerify" runat="server" CommandName="Verify Job" CssClass="btn btn-primary" CommandArgument="<%#Container.DataItemIndex %>" Text="Verify" OnClientClick="OpenVerifyModal()"/>
                                <script>
                                    function OpenVerifyModal() {
                                        $("#verifyJobModal").modal("show");
                                    }
                                </script>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="JobStatus" HeaderText="Job Status" />
                        <asp:BoundField DataField="JobDate" HeaderText="Date" DataFormatString="{0:d}"/>
                        <asp:BoundField DataField="JobStartTime" HeaderText="Start Time" />
                        <asp:BoundField DataField="EndTime" HeaderText="End Time" />
                        <asp:BoundField DataField="ClientID" HeaderText="Client ID" />
                        <asp:BoundField DataField="ContractorID" HeaderText="Contractor ID" />
                        <asp:BoundField DataField="JobStreet" HeaderText="Street" />
                        <asp:BoundField DataField="JobSuburb" HeaderText="Suburb" />
                        <asp:BoundField DataField="JobState" HeaderText="State" />
                        <asp:BoundField DataField="JobPostCode" HeaderText="Post Code" />
                        <asp:BoundField DataField="JobUrgency" HeaderText="Urgency" />
                        <asp:BoundField DataField="SkillName" HeaderText="Skill" />
                        <asp:BoundField DataField="JobDetails" HeaderText="Details" />
                        <asp:BoundField DataField="DistanceTravelled" HeaderText="Distance Travelled (km)" />
                        
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
                <div id="verifyJobModal" class="w3-modal fade" tabindex="-1" role="dialog" data-backdrop="false">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Verify Job</h4>
                            </div>
                            <div class="modal-body">
                                <p>Do you wish to send this job out for payment?</p>
                                <div style="display: none;">
                                    <asp:UpdatePanel runat="server" ID="updateVerify">
                                        <ContentTemplate>
                                            <input type="text" id="txtVerifyClientID" readonly runat="server" />
                                    <input type="text" id="txtVerifyJobDate" readonly runat="server" />
                                    <input type="text" id="txtVerifyJobStartTime" readonly runat="server" />
                                        </ContentTemplate>
                                        <Triggers>
                                            <asp:AsyncPostBackTrigger ControlID="gvActiveJobRequests" EventName="RowCommand" />
                                        </Triggers>
                                    </asp:UpdatePanel>

                                    
                                </div>
                            </div>
                            <div class="modal-footer">
                                <asp:Button runat="server" CssClass="btn btn-primary" ID="btnVerifyJob" method="post" Text="Verify Job" OnClick="btnVerifyJob_Click" />
                                <button class="btn btn=secondary" type="button" data-dismiss="modal">Cancel</button>
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
        <div class="w3-cell-row">
            <div class="col-12">
                <asp:GridView runat="server" class="table table-striped table-bordered" ID="gvAllJobRequests" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="JobDate" HeaderText="Date" DataFormatString="{0:d}"/>
                        <asp:BoundField DataField="JobStartTime" HeaderText="Start Time" />
                        <asp:BoundField DataField="EndTime" HeaderText="End Time" />
                        <asp:BoundField DataField="ClientID" HeaderText="Client ID" />
                        <asp:BoundField DataField="ContractorID" HeaderText="Contractor ID" />
                        <asp:BoundField DataField="JobStreet" HeaderText="Street" />
                        <asp:BoundField DataField="JobSuburb" HeaderText="Suburb" />
                        <asp:BoundField DataField="JobState" HeaderText="State" />
                        <asp:BoundField DataField="JobPostCode" HeaderText="Post Code" />
                        <asp:BoundField DataField="JobUrgency" HeaderText="Urgency" />
                        <asp:BoundField DataField="SkillName" HeaderText="Skill" />
                        <asp:BoundField DataField="JobDetails" HeaderText="Details" />
                        <asp:BoundField DataField="DistanceTravelled" HeaderText="Distance Travelled (km)" />
                        <asp:BoundField DataField="JobStatus" HeaderText="Job Status" />
                    </Columns>
                    <EmptyDataTemplate>No Jobs Found</EmptyDataTemplate>
                </asp:GridView>
                <script>
                    $(document).ready(function () {
                        $("#MainContent_txtAllJobSearch").on("keyup", function () {
                            var value = $(this).val().toLowerCase();
                            $("#MainContent_gvAllJobRequests tr:not(:first-child)").filter(function () {
                                $(this).toggle($(this).text().toLowerCase().indexOf(value) > -1)
                            });
                        });
                    });
                </script>
            </div>
        </div>
    </div>
</asp:Content>
