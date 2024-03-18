﻿Imports System.Collections.Generic

Public Interface ICrud(Of T)
        Function GetAll() As IEnumerable(Of T)
        Function GetById(id As Integer) As T
        Sub Insert(entity As T)
        Sub Update(entity As T)
        Sub Delete(id As Integer)
    End Interface

