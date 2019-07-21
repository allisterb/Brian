namespace Brian

open System

/// Logging interface
[<AbstractClass>]
type Logger() =
    static member val IsConfigured = false with get,set
    
    abstract member Info : messageTemplate:string * [<ParamArray>]args:obj[] -> unit
    abstract member Debug : messageTemplate:string * [<ParamArray>]args:obj[] -> unit
    abstract member Error : messageTemplate:string * [<ParamArray>]args:obj[] -> unit
    abstract member Error : ex:Exception * messageTemplate:string * [<ParamArray>]args:obj[] -> unit

/// Basic console logger available anywhere
type ConsoleLogger() =
    inherit Logger()

    override __.Debug (messageTemplate:string, [<ParamArray>] args: obj[]) = 
        String.Format(messageTemplate, args) |> printfn "%s"
    override __.Info (messageTemplate:string, [<ParamArray>] args: obj[])  = 
        String.Format(messageTemplate, args) |> printfn "%s"
    override __.Error (messageTemplate:string, [<ParamArray>] args: obj[])  = 
        String.Format(messageTemplate, args) |> printfn "%s"
    override __.Error (ex: Exception, messageTemplate:string, [<ParamArray>] args: obj[])  = 
        String.Format(messageTemplate, args) |> printfn "%s"