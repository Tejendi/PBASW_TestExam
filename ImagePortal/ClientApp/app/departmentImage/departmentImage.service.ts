import { Injectable } from "@angular/core";
import { DepartmentImage, Department } from "./DepartmentImage";
import { Observable } from "rxjs/Observable";
import { Http } from "@angular/http";
import "rxjs/add/operator/map";

@Injectable()
export class DepartmentImageService {

    constructor(private http: Http) { }

    upload(fileToUpload: any) {
        let input = new FormData();
        input.append("file", fileToUpload);

        return this.http.post("/api/DepartmentImage/UploadDepartmentImages", input);
    }

    getDepartments(): Observable<Department[]> {
        return this.http.get("/api/Department/GetDepartments").map(x => {
            return x.json().data as Department[];
        });
    }

    getImagesForDepartment(department: Department): Observable<DepartmentImage[]> {
        return this.http.get("/api/DepartmentImage/GetDepartmentImages?cno=" + department.companyNo + "&dno=" + department.departmentNo).map(x => {
            return x.json().data as DepartmentImage[];
        });
    }

    deleteImage(id: any) {
        return this.http.delete("/api/DepartmentImage/DeleteDepartmentImage?id=" + id);
    }

}