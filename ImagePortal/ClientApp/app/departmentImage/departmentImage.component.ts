import { Component, ViewChild } from '@angular/core';
import { DepartmentImageService } from "./departmentImage.service";
import { Department, DepartmentImage } from "./DepartmentImage"
import { Observable } from 'rxjs/Observable';

@Component({
    selector: 'departmentImage',
    providers: [
        DepartmentImageService
    ],
    templateUrl: './departmentImage.component.html'
})
export class DepartmentImageComponent {

    constructor(private departmentImageService: DepartmentImageService) { }

    ngOnInit() {
        this.departments$ = this.departmentImageService.getDepartments();
    }

    getImagesForDepartment(department: Department) {
        this.departmentImages$ = this.departmentImageService.getImagesForDepartment(department);
    }

    @ViewChild("fileInput") fileInput: any;
    addFile(): void {
        let fi = this.fileInput.nativeElement;
        if (fi.files && fi.files[0]) {
            let fileToUpload = fi.files[0];
            this.departmentImageService.upload(fileToUpload).subscribe(() => {
                this.departmentImages$ =
                    this.departmentImageService.getImagesForDepartment(this.item.selectedDepartment);
                });
        }
    }

    deleteImage(image: any): void {
        if (confirm("Are you sure you want to delete the image?")) {
            this.departmentImageService.deleteImage(image.id).subscribe(() => {
                this.departmentImages$ =
                    this.departmentImageService.getImagesForDepartment(this.item.selectedDepartment);
            });
        }
    }

    item: any = {
        selectedDepartment: null
    };

    departments$: Observable<Department[]>;
    departmentImages$: Observable<DepartmentImage[]>;
}