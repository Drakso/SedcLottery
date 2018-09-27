// This is the service for communicating with the backend
// Here we import the dependency injection framework from angular, http client, the IUSerCodeAward interface, observables from rxjs and enviroments ( dev, feature, production etc )
import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { IUserCodeAward } from "./winners-list.model";
import { Observable } from "rxjs";
import { environment } from "../../environments/environment";

// The injector is the root injector that is created during the bootstrap process and by Angular it self so we can inject this service in places
@Injectable({
    providedIn: 'root'
})
// Here we export the service and expose a method getAllWinners that creates an observable that listens for a response froma http get call made with the http client to our back end
export class WinnersListService {
    constructor(private http: HttpClient) {}

    getAllWinners(): Observable<Array<IUserCodeAward>> {
        return this.http.get<Array<IUserCodeAward>>(environment.webApiUrl + "getAllWinners");
    }
}