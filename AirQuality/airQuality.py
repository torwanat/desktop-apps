from tkinter import *
import requests
import json

window = Tk()
window.title('Jakość powietrza')

appWidth = 750
appHeight = 200

screenWidth = window.winfo_screenwidth()
screenHeight = window.winfo_screenheight()

x = (screenWidth / 2) - (appWidth / 2)
y = (screenHeight / 2) - (appHeight / 2)

window.geometry(f'{appWidth}x{appHeight}+{int(x)}+{int(y)}')
window.configure(background='white')

option = StringVar(value="")

def showOptions():
    idList = []
    nameList = []
    apiRequestCity = requests.get('https://api.gios.gov.pl/pjp-api/rest/station/findAll')
    apiCity = json.loads(apiRequestCity.content)
    for city in apiCity:
        if city['city']['name'] == 'Kraków':
            idList.append(city['id'])
            nameList.append(city['stationName'])
    optionsWindow = Toplevel()

    option.set(nameList[0])

    for station in nameList:
        button = Radiobutton(optionsWindow, text=station, variable=option, value=station)
        button.pack(anchor=W)

    goButton = Button(optionsWindow, text='Wybierz', command=lambda: [getData(), optionsWindow.destroy()])
    goButton.pack()


def getData():
    try:
        stationId = '400'
        city = "Kraków"
        coSensorId = '2745'
        pm10SensorId = '2750'
        pm25SensorId = '2752'
        apiRequestCity = requests.get('https://api.gios.gov.pl/pjp-api/rest/station/findAll')
        apiCity = json.loads(apiRequestCity.content)
        for station in apiCity:
            if station['stationName'] == option.get():
                city = option.get()
                stationId = station['id']
                print(city)

        apiRequestSensors = requests.get('https://api.gios.gov.pl/pjp-api/rest/station/sensors/' + stationId)
        apiSensor = json.loads(apiRequestSensors.content)
        coSensorId = apiSensor[0]['id']
        # pm10SensorId = apiSensor[2]['id']
        # pm25SensorId = apiSensor[3]['id']
        co = apiSensor[0]['param']['paramName']
        pm10 = apiSensor[2]['param']['paramName']
        pm25 = apiSensor[3]['param']['paramName']
        print("here")
        apiValueUrl = 'https://api.gios.gov.pl/pjp-api/rest/data/getData/'+coSensorId
        apiRequestValue = requests.get(apiValueUrl)
        apiValue = json.loads(apiRequestValue.content)
        coValue = apiValue['values'][0]['value']
        print(coValue)

        apiRequestValue = requests.get('https://api.gios.gov.pl/pjp-api/rest/data/getData/' + pm10SensorId)
        apiValue = json.loads(apiRequestValue.content)
        pm10Value = apiValue['values'][0]['value']

        apiRequestValue = requests.get('https://api.gios.gov.pl/pjp-api/rest/data/getData/' + pm25SensorId)
        apiValue = json.loads(apiRequestValue.content)
        pm25Value = apiValue['values'][0]['value']

        indexRequestValue = requests.get('https://api.gios.gov.pl/pjp-api/rest/aqindex/getIndex/' + stationId)
        indexValue = json.loads(indexRequestValue.content)
        coIndex = indexValue['stIndexLevel']['indexLevelName']
        pm10Index = indexValue['pm10IndexLevel']['indexLevelName']
        pm25Index = indexValue['pm25IndexLevel']['indexLevelName']


        cityLabel = Label(window, text=city, background='white', font=('Helvetica', 20))
        cityLabel.grid(column=0, row=0, columnspan=2, sticky=EW)
        coLabelName = Label(window, text=co, font=('Helvetica', 20))
        coLabelName.grid(column=0, row=1, sticky=NS)
        coLabelValue = Label(window, text=coValue, font=('Helvetica', 20))
        coLabelValue.grid(column=1, row=1, sticky=NS)
        pm10LabelName = Label(window, text=pm10, font=('Helvetica', 20))
        pm10LabelName.grid(column=0, row=2, sticky=NS)
        pm10LabelValue = Label(window, text=pm10Value, font=('Helvetica', 20))
        pm10LabelValue.grid(column=1, row=2, sticky=NS)
        pm25LabelName = Label(window, text=pm25, font=('Helvetica', 20))
        pm25LabelName.grid(column=0, row=3, sticky=NS)
        pm25LabelValue = Label(window, text=pm25Value, font=('Helvetica', 20))
        pm25LabelValue.grid(column=1, row=3, sticky=NS)
        coLabelIndex = Label(window, text=coIndex, font=('Helvetica', 20))
        coLabelIndex.grid(column=2, row=1, sticky=NS)
        pm10LabelIndex = Label(window, text=pm10Index, font=('Helvetica', 20))
        pm10LabelIndex.grid(column=2, row=2, sticky=NS)
        pm10LabelIndex = Label(window, text=pm25Index, font=('Helvetica', 20))
        pm10LabelIndex.grid(column=2, row=3, sticky=NS)
        optionsButton = Button(window, text='Wybierz stacje', command=showOptions)
        optionsButton.grid(column=1, row=4)
    except Exception as apiError:
        api = 'Error'


getData()

window.mainloop()
