namespace Brian

open System
open Serilog

type SerilogLogger(?logFileName: string) = 
    inherit Brian.Logger()
    
    let file = defaultArg logFileName "Brian.log"

    let config = 
        LoggerConfiguration().WriteTo.File(path = file, outputTemplate=
            "{Timestamp:HH:mm:ss} [{Level:u3}] {Message}{NewLine}{Exception}") 
        
    let logger = 
        let l = config.CreateLogger()
        Logger.IsConfigured <- true
        l
        
    override this.Debug (messageTemplate:string, [<ParamArray>] args: obj[]) = logger.Debug(messageTemplate, args)
    override this.Info (messageTemplate:string, [<ParamArray>] args: obj[]) = logger.Information(messageTemplate, args)
    override this.Error (messageTemplate:string, [<ParamArray>] args: obj[]) = logger.Error(messageTemplate, args)
    override this.Error (ex: Exception, messageTemplate:string, [<ParamArray>] args: obj[]) = 
        logger.Error(ex, messageTemplate, args)
