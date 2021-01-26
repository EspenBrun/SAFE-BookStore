module Client.Tomato

open Client.Styles
open Fable.React

type Model = {
    Color:string
}

let init() =
    { Color = "red" }

let view model =
    div []
        [
            div [] [words 60 "Tomatoes taste VERY good!"]
            div [] [words 20 (sprintf "The color of a tomato is %s" model.Color)]
        ]
