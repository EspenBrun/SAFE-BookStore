module Client.Tomato

open Client.Styles
open Fable.React
open Fable.React.Props

type Model = {
    Color:string
}

type Msg =
    | ChangeColor of string

let init() =
    { Color = "red" }

let view model dispatch =
    div []
        [
            div [] [words 60 "Tomatoes taste VERY good!"]
            div [] [words 20 (sprintf "The color of a tomato is %s" model.Color)]
            br []
            button [
                ClassName ("btn btn-primary")
                OnClick (fun _ -> dispatch (ChangeColor "green"))]
                [str "No, my tomatoes are green!"]
        ]
