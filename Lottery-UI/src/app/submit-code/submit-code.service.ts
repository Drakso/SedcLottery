import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import { IUserCode, IAward } from "../winners-list/winners-list.model";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
})
export class SubmitCodeService {
    lotteryUrl: string = "http://localhost:13596/api/lottery/";
    constructor(private http: HttpClient) {}

    submitCode(userCode: IUserCode) : Observable<IAward> {
        return this.http.post<IAward>(this.lotteryUrl + 'submitCode', userCode);
    }
}