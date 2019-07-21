namespace Brian.Tests

open System

open Brian

type TestApi(init) =
    inherit Api() 
    
    do Api.SetDefaultLoggerIfNone()

    override this.Initialized with get() = init
