import os

def copy_csharp_files_to_single_file(project_directory, output_file, exclude_directories=None):
    """
    Просматривает все файлы C# и Razor в указанной директории проекта и копирует их
    содержимое в один файл, исключая указанные директории.

    Аргументы:
        project_directory: Корневая директория C# проекта.
        output_file: Имя файла, в который будет записано содержимое всех C# и Razor файлов.
        exclude_directories: Список директорий, которые нужно исключить из поиска.
                           Если None, то никакие директории не исключаются.
    """

    if exclude_directories is None:
        exclude_directories = []

    with open(output_file, 'w', encoding='utf-8') as outfile:
        for root, dirs, files in os.walk(project_directory):

            # Преобразуем путь к относительному пути от project_directory
            relative_path = os.path.relpath(root, project_directory)

            # Проверяем, является ли текущая директория или любая из ее родительских директорий в списке исключенных
            if any(os.path.normpath(os.path.join(project_directory, exclude_dir)) in os.path.normpath(root) for exclude_dir in exclude_directories):
                continue  # Пропускаем эту директорию и все ее поддиректории


            for filename in files:
                if filename.endswith((".cs", ".razor")):  # Проверяем расширение файла
                    filepath = os.path.join(root, filename)
                    try:
                        with open(filepath, 'r', encoding='utf-8') as infile:
                            content = infile.read()
                            print(f"//--- File: {filepath} ---\n\n")
                            outfile.write(f"//--- File: {filepath} ---\n\n")  # Разделитель
                            outfile.write(content + "\n\n")
                    except Exception as e:
                        print(f"  Ошибка при обработке файла {filepath}: {e}")

if __name__ == "__main__":
    project_directory = "."  # Текущая директория (где скрипт) - измените при необходимости
    output_filename = "all_code.txt"  # Имя выходного файла (изменил расширение)
    excluded_directories = ["Debug", "Release", "obj", "bin", "Migrations"]  # Список исключенных директорий

    copy_csharp_files_to_single_file(project_directory, output_filename, excluded_directories)
    print(f"Все C# и Razor файлы (кроме файлов в {excluded_directories}) из '{project_directory}' скопированы в '{output_filename}'")