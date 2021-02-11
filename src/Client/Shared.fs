module Client.Shared

open ServerCode.Domain

type PageModel =
    | HomePageModel of Home.Model
    | LoginModel of Login.Model
    | NotFoundModel
    | WishListModel of WishList.Model
    | TomatoModel of Tomato.Model

type Model = {
    MenuModel : Menu.Model
    PageModel : PageModel
}

/// The composed set of messages that update the state of the application
type Msg =
    | AppHydrated
    | WishListMsg of WishList.Msg
    | HomePageMsg of Home.Msg
    | LoginMsg of Login.Msg
    | LoggedIn of UserData
    | LoggedOut
    | StorageFailure of exn
    | Logout of unit


// VIEW

open Fable.React
open Fable.React.Props
open Client.Styles

let view model dispatch =
    div [ Key "Application" ] [
        Menu.view { Model = model.MenuModel; OnLogout = (Logout >> dispatch) }
        hr []

        div [ centerStyle "column" ] [
            match model.PageModel with
            | HomePageModel model ->
                yield Home.view model
            | NotFoundModel ->
                yield div [] [ str "The page is not available." ]
            | LoginModel m ->
                yield Login.view { Model = m; Dispatch = (LoginMsg >> dispatch) }
            | WishListModel m ->
                yield WishList.view { Model = m; Dispatch = (WishListMsg >> dispatch) }
            | TomatoModel m ->
                yield Tomato.view m
        ]
    ]
