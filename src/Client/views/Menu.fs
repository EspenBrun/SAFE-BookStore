module Client.Menu

open Fable.React
open Client.Styles
open Client.Pages
open ServerCode.Domain
open Client.Utils

type Model = {
    User : UserData option
    RenderedOnServer : bool
}

type Props = {
    Model : Model
    OnLogout : unit -> unit
}

let view = elmishView "Menu" (fun (props:Props) ->
    div [ centerStyle "row" ] [
        yield viewLink Page.Home "Home"
        yield viewLink Page.Tomato "Tomato"
        match props.Model.User with
        | Some _ ->
            yield viewLink Page.WishList "Wishlist"
            yield menuLink props.OnLogout "Logout"
        | _ ->
            yield viewLink Page.Login "Login"
        yield str ReleaseNotes.Version

        if props.Model.RenderedOnServer then
            yield str " - Rendered on server"
        else
            yield str " - Rendered on client"
    ]
)