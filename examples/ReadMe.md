Step-1:
Create a razor file for particular chart like this:
rightclick on pages folder->add->RazorComponent
in the name field(in the bottom) replace Component.razor with your chartName.razor
eg:Pie2d.razor
*Note: Here file name should start with capital
Step-2:
 After the above step new file (chartName.razor) will be created, 
 add this line in this file @page "/chartName" 
 eg:@page "/pie3d"
 After pasting this, keep the necessary code to render this specific chart
Step-3:
In the Solution Explorer, navigate to "Shared" folder,open "NavMenu.razor" file
In the file add this code 
  <div class="nav-item px-3">
            <NavLink class="nav-link" href="chartName" Match="NavLinkMatch.All">
                <span class="oi oi-home" aria-hidden="true"></span>chartName
            </NavLink>
        </div>
Note : here in the above div , href attribute value should match with Step-2 value

Important:
1.File name of the razor file of the chart should only be the name of the chart eg:Pie2d.razor 
2.Nav bar should contain name of the chart only
eg: Pie 2D, Column 3D etc

