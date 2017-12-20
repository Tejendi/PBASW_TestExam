import { NgModule } from "@angular/core";
import { CommonModule } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { HttpModule } from "@angular/http";
import { RouterModule } from '@angular/router';
import { DepartmentImageComponent } from "./departmentimage.component";

@NgModule({
    declarations: [
        DepartmentImageComponent
    ],
    imports: [
        HttpModule,
        CommonModule,
        FormsModule,
        RouterModule.forRoot([
            { path: 'department-images', component: DepartmentImageComponent }
        ])
    ],
    exports: [
        DepartmentImageComponent]
})
export class DepartmentImageModule {
}