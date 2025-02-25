import { HttpClient } from "@angular/common/http";
import { BackendError } from "../models/backend-error.model";
import { throwError } from "rxjs";

export class BaseService {
    public catchProblemDetailsError(error : any) {
        const apiError: BackendError = {
            status: error.status,
            title: error.error?.title,
            detail: error.error?.detail,
            errors: error.error?.errors
          };

        return throwError(() => apiError);
    }
}