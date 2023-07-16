import Catalog from "../../features/catalog/Catalog";
import { Container, CssBaseline, ThemeProvider, createTheme } from "@mui/material";
import Header from "./Header";
import { useState } from "react";

function App() {

  const [darkMode, setDarkMode] = useState(false);
  const paletteType = darkMode ? 'dark' : 'light';
  const theme = createTheme( {
    palette: {
      mode: paletteType,
      // background: {
      //   default: paletteType=== 'light' ? '#eaeaea' : '#121212'
      // }
    }
  })

  function handleThemeChange() {
    setDarkMode(!darkMode);
  }

  return (
    <ThemeProvider theme={theme}>

      {/* so all .css named.app will change style of this class, we can also do this in-line, like 
      <h1 style={{color:'red'}}>ReStore</h1>  note we used {{}} to indicate a .css object*/}
  
      <CssBaseline />
      
      <Header darkMode={darkMode} handleThemeChange={handleThemeChange}/>
      
      <Container>
         <Catalog />
      </Container>

    </ThemeProvider>
  );
}

export default App;
