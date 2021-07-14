<%@ Page Title="Home Page" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="BITServices_WebForms._Default" EnableEventValidation="false" %>

<asp:Content ID="BodyContent" ContentPlaceHolderID="MainContent" runat="server">

    <header class="w3-display-container w3-content w3-wide" style="max-width:1500px;" id="home">
        <img class="w3-image" src="Images/PlaceHolderImages/architect.jpg" alt="Architecture" width="1500" height="800">
        <div class="w3-display-middle w3-margin-top w3-center">
            <h1 class="w3-xxlarge w3-text-white"><span class="w3-padding w3-black w3-opacity-min" style="font-style: italic;line-height: initial;">"Every modern business needs to be connected..."</span><br><br><span class="w3-padding w3-black w3-opacity-min">That's where we come in.</span></h1>
        </div>
    </header>    

    <div class="w3-content">

        <!-- Project Section -->
         <div class="w3-container w3-padding-32" id="projects">
            <h3 class="w3-border-bottom w3-border-light-grey w3-padding-16">Projects</h3>
         </div>

        <div class="w3-row-padding">
            <div class="w3-col l3 m6 w3-margin-bottom">
                <div class="w3-display-container">
                    <div class="w3-display-topleft w3-black w3-padding">Summer House</div>
                    <img src="Images/PlaceHolderImages/house5.jpg" alt="House" style="width:100%">
                </div>
            </div>
            <div class="w3-col l3 m6 w3-margin-bottom">
                <div class="w3-display-container">
                    <div class="w3-display-topleft w3-black w3-padding">Brick House</div>
                    <img src="Images/PlaceHolderImages/house2.jpg" alt="House" style="width:100%">
                </div>
            </div>
            <div class="w3-col l3 m6 w3-margin-bottom">
                <div class="w3-display-container">
                    <div class="w3-display-topleft w3-black w3-padding">Renovated</div>
                    <img src="Images/PlaceHolderImages/house3.jpg" alt="House" style="width:100%">
                </div>
            </div>
            <div class="w3-col l3 m6 w3-margin-bottom">
                <div class="w3-display-container">
                    <div class="w3-display-topleft w3-black w3-padding">Barn House</div>
                    <img src="Images/PlaceHolderImages/house4.jpg" alt="House" style="width:100%">
                </div>
            </div>
        </div>

        <div class="w3-row-padding">
            <div class="w3-col l3 m6 w3-margin-bottom">
                <div class="w3-display-container">
                    <div class="w3-display-topleft w3-black w3-padding">Summer House</div>
                    <img src="Images/PlaceHolderImages/house2.jpg" alt="House" style="width:99%">
                </div>
            </div>
            <div class="w3-col l3 m6 w3-margin-bottom">
                <div class="w3-display-container">
                    <div class="w3-display-topleft w3-black w3-padding">Brick House</div>
                    <img src="Images/PlaceHolderImages/house5.jpg" alt="House" style="width:99%">
                </div>
            </div>
            <div class="w3-col l3 m6 w3-margin-bottom">
                <div class="w3-display-container">
                    <div class="w3-display-topleft w3-black w3-padding">Renovated</div>
                    <img src="Images/PlaceHolderImages/house4.jpg" alt="House" style="width:99%">
                </div>
            </div>
            <div class="w3-col l3 m6 w3-margin-bottom">
                <div class="w3-display-container">
                    <div class="w3-display-topleft w3-black w3-padding">Barn House</div>
                    <img src="Images/PlaceHolderImages/house3.jpg" alt="House" style="width:99%">
                </div>
            </div>
        </div> 
        <!-- About Section -->
        <div class="w3-container w3-padding-32" id="about">
            <h3 class="w3-border-bottom w3-border-light-grey w3-padding-16">About</h3>
            <p>
                Here at BIT Services, we help you stay connected in the vast world of Information Technologies.
                From networking to websites, we are the best in the business and we care for your needs. Serving of 2,500 happy clients, we will make sure your needs are put forth.
            </p>
        </div>

        <div class="w3-row-padding w3-grayscale">
            <div class="w3-col l3 m6 w3-margin-bottom">
                <img src="Images/PlaceHolderImages/team2.jpg" alt="Frank Dudley" style="width:100%">
                <h3>Frank Dudley</h3>
                <p class="w3-opacity">CEO of Business Information Technology</p>
                <p>Phasellus eget enim eu lectus faucibus vestibulum. Suspendisse sodales pellentesque elementum.</p>
            </div>
            <div class="w3-col l3 m6 w3-margin-bottom">
                <img src="Images/PlaceHolderImages/team1.jpg" alt="Jane" style="width:100%">
                <h3>Gary Andrews</h3>
                <p class="w3-opacity">BIT Services Manager</p>
                <p>Phasellus eget enim eu lectus faucibus vestibulum. Suspendisse sodales pellentesque elementum.</p>
            </div>
            <div class="w3-col l3 m6 w3-margin-bottom">
                <img src="Images/PlaceHolderImages/team3.jpg" alt="Mike" style="width:100%">
                <h3>Mike Ross</h3>
                <p class="w3-opacity">Lead Coordinator</p>
                <p>Phasellus eget enim eu lectus faucibus vestibulum. Suspendisse sodales pellentesque elementum.</p>
            </div>
            <div class="w3-col l3 m6 w3-margin-bottom">
                <img src="Images/PlaceHolderImages/team4.jpg" alt="Dan" style="width:100%">
                <h3>Dan Star</h3>
                <p class="w3-opacity">Field Contractor</p>
                <p>Phasellus eget enim eu lectus faucibus vestibulum. Suspendisse sodales pellentesque elementum.</p>
            </div>
        </div>

        <!-- Contact Section -->
        <div class="w3-container w3-padding-32" id="contact">
            <h3 class="w3-border-bottom w3-border-light-grey w3-padding-16">Contact</h3>
            <p>Lets get in touch and talk about your next project.</p>
            <div>
                <input class="w3-input w3-border" type="text" placeholder="Name" name="Name">
                <input class="w3-input w3-section w3-border" type="text" placeholder="Email" name="Email">
                <input class="w3-input w3-section w3-border" type="text" placeholder="Subject" name="Subject">
                <input class="w3-input w3-section w3-border" type="text" placeholder="Comment" name="Comment">
                <button class="w3-button w3-black w3-section" type="submit">
                    <i class="fa fa-paper-plane"></i> SEND MESSAGE
                </button>
            </div>
        </div>

        <!-- Image of location/map -->
        
    </div>
    <div class="w3-display-container w3-content w3-wide" style="max-width:1500px;">
        <img src="Images/PlaceHolderImages/map.jpg" class="w3-image" style="width:100%">
    </div>

</asp:Content>
