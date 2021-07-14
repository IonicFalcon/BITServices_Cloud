<%@ Page Title="Contractor Home Page" Language="C#" MasterPageFile="~/LoggedInMaster.Master" AutoEventWireup="true" CodeBehind="ContractorLandingPage.aspx.cs" Inherits="BITServices_WebForms.ContractorLandingPage" %>
<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="w3-content container">
        <div class="row">
            <div class="col-12">
                <h2 style="display: inline;">Avaliable Job Requests</h2>
                <asp:TextBox runat="server" placeholder="Search" ID="txtAvaliableJobSearch" CssClass="GridViewSearch"/>
            </div>
        </div>
        <div class="row">
            <div class="col-12">
                <asp:GridView runat="server" class="table table-striped table-bordered" ID="gvAvaliableJobRequests" OnRowCommand="gvAvaliableJobRequests_RowCommand" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField HeaderText="Accept or Reject">
                            <ItemTemplate>
                                <asp:Button ID="btnAccept" runat="server" CommandName="Accept" CssClass="btn btn-success" CommandArgument="<%#Container.DataItemIndex%>" Text="Accept" />
                                <asp:Button ID="btnReject" runat="server" CommandName="Reject" CssClass="btn btn-danger" CommandArgument="<%#Container.DataItemIndex%>" Text="Reject" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="ClientID" HeaderText="Client ID" />
                        <asp:BoundField DataField="JobDate" HeaderText="Date" DataFormatString="{0:d}"/>
                        <asp:BoundField DataField="JobStartTime" HeaderText="Start Time" />
                        <asp:BoundField DataField="SkillName" HeaderText="Skill" />
                        <asp:BoundField DataField="JobDetails" HeaderText="Details" />
                        <asp:BoundField DataField="JobStreet" HeaderText="Street" />
                        <asp:BoundField DataField="JobSuburb" HeaderText="Suburb" />
                        <asp:BoundField DataField="JobState" HeaderText="State" />
                        <asp:BoundField DataField="JobPostCode" HeaderText="Post Code" />
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
            </div>
        </div>
        <div class="row" style="margin-top: 50px;">
            <div class="col-12">
                <h2 style="display: inline;">Active Job Requests</h2>
                <asp:TextBox runat="server" placeholder="Search" ID="txtActiveJobSearch" CssClass="GridViewSearch" />
            </div>
        </div>
        <div class="row">
            <div class="col-12">
                <asp:GridView runat="server" class="table table-striped table-bordered" ID="gvActiveJobRequests" OnRowCommand="gvActiveJobRequests_RowCommand" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false">
                    <Columns>
                        <asp:TemplateField HeaderText="Mark Complete">
                            <ItemTemplate>
                                <asp:Button ID="btnMarkComplete" runat="server" CommandName="Mark Complete" CssClass="btn btn-primary" CommandArgument="<%#Container.DataItemIndex %>" Text="Mark Complete" CausesValidation="false" OnClientClick="OpenCompleteModal()"/>
                                <script>
                                    function OpenCompleteModal() {
                                        $("#completeJobModal").modal("show");
                                    }
                                </script>
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="JobDate" HeaderText="Date" DataFormatString="{0:d}"/>
                        <asp:BoundField DataField="JobStartTime" HeaderText="Start Time" />
                        <asp:BoundField DataField="SkillName" HeaderText="Skill" />
                        <asp:BoundField DataField="JobDetails" HeaderText="Details" />
                        <asp:BoundField DataField="JobStreet" HeaderText="Street" />
                        <asp:BoundField DataField="JobSuburb" HeaderText="Suburb" />
                        <asp:BoundField DataField="JobState" HeaderText="State" />
                        <asp:BoundField DataField="JobPostCode" HeaderText="Post Code" />
                        <asp:BoundField DataField="ClientID" HeaderText="Client ID" />
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

                <div id="completeJobModal" class="modal fade" tabindex="-1" role="dialog" data-backdrop="false">
                    <div class="modal-dialog" role="document">
                        <div class="modal-content">
                            <div class="modal-header">
                                <button class="close" data-dismiss="modal">&times;</button>
                                <h4 class="modal-title">Complete Job</h4>
                            </div>
                            <div class="modal-body" style="text-align:center;">
                                <asp:UpdatePanel runat="server" ID="updateComplete">
                                    <ContentTemplate>
                                        <div class="container-fluid" style="border: grey 2px solid; display: inline-block; background: lightgray;">
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <label for="jobDate">Job Date</label>
                                                        <input class="form-control" type="text" name="jobDate" id="txtDate" readonly runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <label for="jobStartTime">Job Start Time</label>
                                                        <input class="form-control" type="text" name="jobStartTime" id="txtStartTime" readonly runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <label for="jobSkill">Skill Name</label>
                                                        <input class="form-control" type="text" name="jobSkill" id="txtSkill" readonly runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <label for="jobDetails">Details</label>
                                                        <input class="form-control" type="text" name="jobDetails" id="txtDetails" readonly runat="server" />
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
                                                        <input type="text" id="txtClientID" readonly runat="server" style="display: none;" />
                                                    </div>
                                                </div>
                                            </div>
                                            
                                        </div>
                                        <div class="container-fluid" style="text-align:left; margin-top:2em;">
                                            <div class="row">
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <label for="jobEndTime">End Time</label>
                                                        <input class="form-control" type="time" name="jobEndTime" id="txtJobEndTime" runat="server" />
                                                    </div>
                                                </div>
                                                <div class="col-lg-6">
                                                    <div class="form-group">
                                                        <label for="jobDistanceTravelled">Distance Travelled (km)</label>
                                                        <input class="form-control" type="text" name="jobDistanceTravelled" id="txtDistanceTravelled" runat="server" />
                                                    </div>
                                                </div>
                                            </div>
                                        </div>
                                    </ContentTemplate>
                                    <Triggers>
                                        <asp:AsyncPostBackTrigger ControlID="gvActiveJobRequests" EventName="RowCommand" />
                                    </Triggers>
                                </asp:UpdatePanel>
                            </div>
                            <div class="modal-footer">
                                <asp:Button CssClass="btn btn-primary" ID="btnCompleteJob" runat="server" Text="Complete Job" method="post" OnClick="btnCompleteJob_Click" />
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
        <div class="w3-cell-row">
            <div class="col-12">
                <asp:GridView runat="server" class="table table-striped table-bordered" ID="gvAllJobRequests" ShowHeaderWhenEmpty="true" AutoGenerateColumns="false">
                    <Columns>
                        <asp:BoundField DataField="JobDate" HeaderText="Date" DataFormatString="{0:d}"/>
                        <asp:BoundField DataField="JobStartTime" HeaderText="Start Time" />
                        <asp:BoundField DataField="EndTime" HeaderText="End Time" />
                        <asp:BoundField DataField="SkillName" HeaderText="Skill" />
                        <asp:BoundField DataField="JobDetails" HeaderText="Details" />
                        <asp:BoundField DataField="JobStreet" HeaderText="Street" />
                        <asp:BoundField DataField="JobSuburb" HeaderText="Suburb" />
                        <asp:BoundField DataField="JobState" HeaderText="State" />
                        <asp:BoundField DataField="JobPostCode" HeaderText="Post Code" />
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
