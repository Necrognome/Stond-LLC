﻿Imports Microsoft.Owin
Imports Owin

'<Assembly: OwinStartupAttribute(GetType(Startup))>

Public Partial Class Startup
    Public Sub Configuration(app As Stond)
        ConfigureAuth(app)
    End Sub
End Class
