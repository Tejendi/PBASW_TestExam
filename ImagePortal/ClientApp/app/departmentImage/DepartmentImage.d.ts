export class DepartmentImage {
    department:Department;
    filename: string;
    sortOrder: number;
    filePath: string;
    size: number;
    height: number;
    width: number;
    fileExtension: string;
}

export class Department {
    companyNo: number;
    departmentNo: number;
    name: string;  
}